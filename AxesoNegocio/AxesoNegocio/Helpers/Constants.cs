using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AxesoNegocio.Helpers
{
    public static class Constants
    {
        public static string AppName = "AxesoNegocio";
		public const string GoogleMapsApiKey = "AIzaSyAJ2Y_hbwcXftOfQbnUD_8ZNjpzwMQ3Dgs";

		public static string GeneraPass()
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var stringChars = new char[8];
			var random = new Random();

			for (int i = 0; i < stringChars.Length; i++)
			{
				stringChars[i] = chars[random.Next(chars.Length)];
			}

			return new String(stringChars);

		}
		public static string EncriptaClave(string token)
		{
			string claveencrip = "";
			try
			{
				SHA1 sha1 = new SHA1CryptoServiceProvider();
				byte[] inputBytes = (new System.Text.UnicodeEncoding()).GetBytes(token);
				byte[] hash = sha1.ComputeHash(inputBytes);

				claveencrip = Convert.ToBase64String(hash);
			}
			catch (Exception ex)
			{

			}
			return claveencrip;
		}

		public const string DatabaseFilename = "Axeso.db3";

		public const SQLite.SQLiteOpenFlags Flags =
			// open the database in read/write mode
			SQLite.SQLiteOpenFlags.ReadWrite |
			// create the database if it doesn't exist
			SQLite.SQLiteOpenFlags.Create |
			// enable multi-threaded database access
			SQLite.SQLiteOpenFlags.SharedCache;

		public static string DatabasePath
		{
			get
			{
				var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				return Path.Combine(basePath, DatabaseFilename);
			}
		}
	}
}
