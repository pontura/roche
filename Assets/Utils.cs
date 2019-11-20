﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Utils {

    public static void RemoveAllChildsIn(Transform container)
    {
        int num = container.transform.childCount;
        for (int i = 0; i < num; i++) UnityEngine.Object.DestroyImmediate(container.transform.GetChild(0).gameObject);
    }

	public static string SetFormatedNumber(string n){
		string[] arr = n.Split (',');

		string returnString = "";
		for (int i = 1; i < arr[0].Length+1; i++) {
			if (i%3 == 0 && i!=arr[0].Length) {				
				returnString = "." + arr[0][arr[0].Length-i] + returnString;
			} else {				
				returnString = arr[0][arr[0].Length-i] + returnString;
			}
		}
		if (arr [0].Length < 1)
			returnString = "0";
		if (arr.Length > 1)
			returnString += ","+arr [1];
		return returnString;
	}

	public static void Shuffle<T>(List<T> list){
		System.Random _random = new System.Random();
		int n = list.Count;
		for (int i = 0; i < n; i++)
		{
			int r = i + _random.Next(n - i);
			T t = list[r];
			list[r] = list[i];
			list[i] = t;
		}
	}

	public static void Shuffle<T>(T[] array){
		System.Random _random = new System.Random ();
		int n = array.Length;
		for (int i = 0; i < n; i++) {
			int r = i + _random.Next (n - i);
			T t = array [r];
			array [r] = array [i];
			array [i] = t;
		}
	}

	static string int2Hex(int c) {
			string hex = c.ToString("X2");
			return hex.Length == 1 ? "0" + hex : hex;
	}

	public static string rgb2Hex(float r, float g, float b) {
		return rgb2Hex ((int)(r*255), (int)(g*255), (int)(b*255));
	}

	public static string rgb2Hex(int r, int g, int b) {
			return "#" + int2Hex(r) + int2Hex(g) + int2Hex(b);
	}

	public static string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

}
