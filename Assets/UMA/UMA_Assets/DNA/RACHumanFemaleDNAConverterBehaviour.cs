using UnityEngine;
using System.Collections;
using UMA;

public class RACHumanFemaleDNAConverterBehaviour : HumanFemaleDNAConverterBehaviour
{    
	public RACHumanFemaleDNAConverterBehaviour()
	{
		this.ApplyDnaAction = UpdateRACFemaleDNABones;
		this.DNAType = typeof(UMADnaHumanoid);
	}

	public static void UpdateRACFemaleDNABones (UMAData umaData, UMASkeleton skeleton)
	{
		HumanFemaleDNAConverterBehaviour.UpdateUMAFemaleDNABones (umaData, skeleton);

//		skeleton.SetPosition(UMASkeleton.StringToHash("LeftShoulder"),
//		                     skeleton.GetPosition(UMASkeleton.StringToHash("LeftShoulder")) +
//		                     new Vector3(
//			Mathf.Clamp(0, -10, 10),
//			-umaDna.shoulder,
//			Mathf.Clamp(0, -10, 10)));
//		skeleton.SetPosition(UMASkeleton.StringToHash("RightShoulder"),
//		                     skeleton.GetPosition(UMASkeleton.StringToHash("RightShoulder")) +
//		                     new Vector3(
//			Mathf.Clamp(0, -10, 10),
//			umaDna.shoulder,
//			Mathf.Clamp(0, -10, 10)));
	}

}
