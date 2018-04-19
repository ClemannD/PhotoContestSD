using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageForViewing : ImageEntry {

	public UsersImagePrefabValues values;
	public string theme;
	public int place;

	public ImageForViewing(NetworkAPI.GetUserImagesImageInfo.imageInfo info):base(info.user_id,info.image_id,info.image_url,info.contest_id,info.description,info.username,info.votes,((info.isFlagged == 1) ? true : false)){
		this.theme = info.category;
		this.place = info.place;
	}

	public void AttachUI(UsersImagePrefabValues values){
		this.values = values;
		this.values.SetImageTexture (entryImage);
		this.values.SetDescription (description);
		this.values.SetContestInfo (theme);
		this.values.SetVotes (votes);
		this.values.SetPlace (place);
	}
}
