using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For an object holding a link to a server image. Use this class to download and set the image. 
/// </summary>
public interface IServerImage{

	string GetServerURL ();

	void SetTexture (Texture t);
}
