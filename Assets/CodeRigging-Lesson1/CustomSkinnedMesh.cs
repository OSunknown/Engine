using UnityEngine;
using System.Collections;

public class CustomSkinnedMesh : MonoBehaviour {

    public Material mat;
    public Transform[] bones;

	// Use this for initialization
	void Start ()
    {
        Mesh m = new Mesh();
        m.vertices = new Vector3[]
        {
			//오른쪽 다리

				//down
			new Vector3(-2f,0.0f,-0.5f), //0
			new Vector3(-1f,0.0f,-0.5f),
			new Vector3(-1f,0.0f,0.5f),
			new Vector3(-2f,0.0f,0.5f),

				//up
			new Vector3(-2f,2.0f,-0.5f),//4
			new Vector3(-1f,2.0f,-0.5f),
			new Vector3(-1f,2.0f,0.5f),
			new Vector3(-2f,2.0f,0.5f),

			//오른쪽 다리

				//down
			new Vector3(1f,0.0f,-0.5f), //8
			new Vector3(2f,0.0f,-0.5f),
			new Vector3(2f,0.0f,0.5f),
			new Vector3(1f,0.0f,0.5f),

				//up
			new Vector3(1f,2.0f,-0.5f), //12
			new Vector3(2f,2.0f,-0.5f),
			new Vector3(2f,2.0f,0.5f),
			new Vector3(1f,2.0f,0.5f),

			//body Under
			new Vector3(-2f,2.0f,-1.5f), //16
			new Vector3(2f,2.0f,-1.5f),
			new Vector3(2f,2.0f,1.5f),
			new Vector3(-2f,2.0f,1.5f),
			//Body Up
			new Vector3(-2f,6.0f,-1.5f), //20
			new Vector3(2f,6.0f,-1.5f),
			new Vector3(2f,6.0f,1.5f),
			new Vector3(-2f,6.0f,1.5f),

			//Right Arm
				//begin
			new Vector3(-2f,6.0f,-0.5f), //24
			new Vector3(-2f,5.0f,-0.5f),
			new Vector3(-2f,5.0f,0.5f),
			new Vector3(-2f,6.0f,0.5f),
				//end
			new Vector3(-6f,6.0f,-0.5f), //28
			new Vector3(-6f,5.0f,-0.5f),
			new Vector3(-6f,5.0f,0.5f),
			new Vector3(-6f,6.0f,0.5f),
			//Left Arm
				//begin
			new Vector3(2f,6.0f,-0.5f), //32
			new Vector3(2f,5.0f,-0.5f),
			new Vector3(2f,5.0f,0.5f), //34
			new Vector3(2f,6.0f,0.5f), //35
				//end
			new Vector3(6f,6.0f,-0.5f), //36
			new Vector3(6f,5.0f,-0.5f),
			new Vector3(6f,5.0f,0.5f),
			new Vector3(6f,6.0f,0.5f),

			//head
			new Vector3(0f,6.0f,0f), //40
			new Vector3(-2f,8.0f,0f),
			new Vector3(2f,8.0f,0f),
			new Vector3(0f,10.0f,0f)
		};

        m.triangles = new int[] {
			//RightLeg
			0,1,2,0,3,2,
			0,4,5,0,1,5,
			0,7,4,0,3,7,
			2,1,5,2,6,5,
			2,3,7,2,7,6,
			//LeftLeg
			8,9,10,8,11,10,
			8,12,13,8,9,13,
			8,15,12,8,11,15,
			10,9,13,10,14,13,
			10,11,15,10,15,14,

			//bodyunder

			16,4,5,16,5,12,16,12,13,16,13,17,
			5,12,15,5,6,15,
			19,7,6,19,6,15,19,15,14,19,18,14,

			//body 
			16,21,17,16,20,21,
			18,19,23,18,23,22,
			16,20,24,16,24,25,
			16,25,19,19,25,26,

			19,26,23,23,26,27,
			17,21,32,17,32,33,
			17,18,33,18,33,34,
			18,34,22,34,35,22,

			20,21,22,20,23,22,
			//Right arm
			28,29,30,28,30,31,
			24,28,29,24,29,25,
			24,28,31,24,27,31,
			25,29,30,25,26,30,
			27,31,30,27,26,30,

			//Left arm
			36,37,38,36,38,39,
			32,33,36,33,36,37,
			33,34,37,37,38,34,
			34,35,38,35,38,39,
			32,35,39,32,36,39,

			//Head,

			40,43,42,40,43,41,
		};
        m.bindposes = new Matrix4x4[]
        {
            bones[0].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[1].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[2].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[3].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[4].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[5].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[6].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[7].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[8].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[9].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[10].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[11].worldToLocalMatrix * transform.localToWorldMatrix,
			bones[12].worldToLocalMatrix * transform.localToWorldMatrix,
        };

        m.boneWeights = new BoneWeight[]
        {
			new BoneWeight() {boneIndex0 = 0, weight0 = 0.25f },
			new BoneWeight() { boneIndex0 = 0, weight0 = 0.25f },
            new BoneWeight() { boneIndex0 = 1, weight0 = 1f },
			new BoneWeight() { boneIndex0 = 2, weight0 = 1f },

			new BoneWeight() { boneIndex0 = 0, weight0 = 0.25f },
			new BoneWeight() { boneIndex0 = 4, weight0 = 1f },
			new BoneWeight() { boneIndex0 = 5, weight0 = 1f },
			new BoneWeight() { boneIndex0 = 11, weight0 = 0.25f },

			new BoneWeight() { boneIndex0 = 7, weight0 = 0.5f },
			new BoneWeight() { boneIndex0 = 11, weight0 = 0.25f},
			new BoneWeight() { boneIndex0 = 8, weight0 = 0.5f },
			new BoneWeight() { boneIndex0 = 0, weight0 = 0.5f },
			new BoneWeight() { boneIndex0 = 11, weight0 = 0.25f },
        };

		m.colors = new Color[]
		{
			Color.red,
			Color.red,
			Color.red,
			Color.red,
			Color.black,
			Color.black,
			Color.black,
			Color.black,

			Color.red,
			Color.red,
			Color.red,
			Color.red,
			Color.black,
			Color.black,
			Color.black,
			Color.black,

			Color.blue,
			Color.blue,
			Color.blue,
			Color.blue,

			Color.green,
			Color.green,
			Color.green,
			Color.green,
			//arm
			Color.blue,
			Color.blue,
			Color.blue,
			Color.blue,

			Color.red,
			Color.red,
			Color.red,
			Color.red,

			//arm
			Color.blue,
			Color.blue,
			Color.blue,
			Color.blue,

			Color.red,
			Color.red,
			Color.red,
			Color.red,

			Color.white,
			Color.white,
			Color.white,
			Color.white,
		};


        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();
        smr.sharedMesh = m;
        smr.sharedMaterial = mat;
        smr.bones = bones;
        smr.rootBone = transform;
        smr.quality = SkinQuality.Bone1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
