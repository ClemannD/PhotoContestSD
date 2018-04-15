using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningImageEntry : ImageEntry {

	public WinningImageEntry(NetworkAPI.imageInfo info):base(info.user_id,info.image_id,info.image_url,info.contest_id,info.description,info.username,info.votes,((info.isFlagged == 1) ? true : false)){

	}


	public void AttachUI(WinningImagePrefabValues values){

			values.SetImageTexture (entryImage);
			values.SetDescription (description);
			values.SetAuthorInfo (authorInfo);
			values.SetVotes (votes);
	}
}
