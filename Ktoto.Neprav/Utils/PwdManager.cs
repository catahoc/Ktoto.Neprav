using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ktoto.Neprav.Utils
{
	public static class PwdManager
	{
		public class PwdData 
		{
			public PwdData(string salt, byte[] hash)
			{
				Salt = salt;
				Hash = hash;
			}

			public byte[] Hash { get; set; }
			public string Salt { get; set; }
		}

		private static readonly MD5 HashFunction = MD5.Create();

		public static PwdData ComputeHash(string pwd)
		{
			var salt = GetRandomString(32);
			var pwdExt = salt + pwd + salt;
			var hash = HashFunction.ComputeHash(Encoding.UTF8.GetBytes(pwdExt));
			return new PwdData(salt, hash);
		}

		public static bool IsCorrect(PwdData pwdData, string pwd)
		{
			var salt = pwdData.Salt;
			var pwdExt = salt + pwd + salt;
			var hash = HashFunction.ComputeHash(Encoding.UTF8.GetBytes(pwdExt));
			return hash.SequenceEqual(pwdData.Hash);
		}

		private static string GetRandomString(int length)
		{
			var r = new Random();
			var chars = new char[length];
			for (int i = 0; i < length; i++)
			{
				chars[i] = (char) (r.Next()%0xfff0 + 10);
			}
			return new string(chars);
		}
	}
}