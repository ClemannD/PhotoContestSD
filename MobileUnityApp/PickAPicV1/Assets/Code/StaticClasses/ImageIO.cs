using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageIO {

	public static Texture2D MakeImageFromFile(string filePath){
		System.Drawing.Image pic = System.Drawing.Image.FromFile (filePath);
		Texture2D t = new Texture2D (pic.Width, pic.Height);
		byte[] imageBytes = File.ReadAllBytes (filePath);
		ImageConversion.LoadImage (t, imageBytes);
		return t;
	}
}
