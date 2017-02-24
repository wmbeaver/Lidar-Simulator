﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace AssemblyCSharp
{
	/// <summary>
	///  This class is used to export and load data generated by the lidar sensor. 
	/// </summary>
    public class ExportLoadData : MonoBehaviour
    {


        public ExportLoadData()
        {
        }

		/// <summary>
		/// Saves the lidar data into a file at the deffault application storage.
		/// </summary>
		/// <returns><c>true</c>, If the lidar data was saved, <c>false</c> otherwise.</returns>
		/// <param name="data">Data.</param>
		/// <param name="fileName">File name.</param>
        public static Boolean SaveLidarData(Dictionary<float, List<SphericalCoordinates>> data, String fileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath + "/"+fileName+".lidar");
			bf.Serialize(file, (JsonUtility.ToJson(data)));
            file.Close();
			return File.Exists (Application.persistentDataPath + "/" + fileName + ".lidar"); 
        }
		/// <summary>
		/// Opens and deserializes the data with a given file name
		/// </summary>
		/// <returns>The data.</returns>
		/// <param name="fileName">File name.</param>
		public static Dictionary<float, List<SphericalCoordinates>> OpenData(String fileName)
        {
			if (File.Exists(Application.persistentDataPath + "/" + fileName + ".lidar")) {
            BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/" + fileName + ".lidar", FileMode.Open);
            Dictionary<float,List<SphericalCoordinates>> data = (Dictionary<float,List<SphericalCoordinates>>) bf.Deserialize(file);
            file.Close();
            return data;

          } else {
            throw new FileNotFoundException();
          }

        }

		/// <summary>
		/// Retrieves all the save files at the default save location.
		/// </summary>
		/// <returns>The files.</returns>
		public static List<String> GetFiles() 
		{
			Path path = new DirectoryInfo (Application.persistentDataPath);
			List<String> files = new List<string> ();
			foreach (string file in System.IO.Directory.GetFiles(path))
			{ 
				files.Add (file);
			}
			return files;
		}
    }
}
