using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MCSkinnedCharacter : MonoBehaviour {


    public Transform[] bones;

    float meshSize = 0.1f;
    float uvSize = 0.0625f;

    Vector3[] GetVertexArray(Vector3 origin, Vector3 size)
    {
        return new Vector3[] {
            // Front
            new Vector3(-size.x, -size.y, -size.z) * meshSize + origin,
            new Vector3(-size.x, size.y, -size.z) * meshSize + origin,
            new Vector3(size.x, size.y, -size.z) * meshSize + origin,
            new Vector3(size.x, -size.y, -size.z) * meshSize + origin,
            // Top
            new Vector3(-size.x, size.y, -size.z) * meshSize + origin,
            new Vector3(-size.x, size.y, size.z) * meshSize + origin,
            new Vector3(size.x, size.y, size.z) * meshSize + origin,
            new Vector3(size.x, size.y, -size.z) * meshSize + origin,
            // Left
            new Vector3(-size.x, -size.y, -size.z) * meshSize + origin,
            new Vector3(-size.x, size.y, -size.z) * meshSize + origin,
            new Vector3(-size.x, size.y, size.z) * meshSize + origin,
            new Vector3(-size.x, -size.y, size.z) * meshSize + origin,
            // Right
            new Vector3(size.x, -size.y, -size.z) * meshSize + origin,
            new Vector3(size.x, size.y, -size.z) * meshSize + origin,
            new Vector3(size.x, size.y, size.z) * meshSize + origin,
            new Vector3(size.x, -size.y, size.z) * meshSize + origin,
            // Back
            new Vector3(size.x, -size.y, size.z) * meshSize + origin,
            new Vector3(size.x, size.y, size.z) * meshSize + origin,
            new Vector3(-size.x, size.y, size.z) * meshSize + origin,
            new Vector3(-size.x, -size.y, size.z) * meshSize + origin,
            // Bottom
            new Vector3(size.x, -size.y, -size.z) * meshSize + origin,
            new Vector3(size.x, -size.y, size.z) * meshSize + origin,
            new Vector3(-size.x, -size.y, size.z) * meshSize + origin,
            new Vector3(-size.x, -size.y, -size.z) * meshSize + origin
        };
    }

    int[] GetIndexArray(int startIndex)
    {
        int[] tempIndex = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            4, 5, 6,
            4, 6, 7,
            8, 10, 9,
            8, 11, 10,
            12, 13, 14,
            12, 14, 15,
            16, 17, 18,
            16, 18, 19,
            20, 21, 22,
            20, 22, 23
        };

        for(int i = 0; i < tempIndex.Length; ++i)
        {
            tempIndex[i] += startIndex;
        }

        return tempIndex;
    }

    Vector2[] GetUVArray(Vector2 origin, Vector3 size)
    {
        return new Vector2[]
        {
            // Front
            origin + new Vector2(size.z, 0f) * uvSize,
            origin + new Vector2(size.z, size.y) * uvSize,
            origin + new Vector2(size.z + size.x, size.y) * uvSize,
            origin + new Vector2(size.z + size.x, 0f) * uvSize,
            // Top
            origin + new Vector2(size.z, size.y) * uvSize,
            origin + new Vector2(size.z, size.y + size.z) * uvSize,
            origin + new Vector2(size.z + size.x, size.y + size.z) * uvSize,
            origin + new Vector2(size.z + size.x, size.y) * uvSize,
            // Left
            origin + new Vector2(size.z + size.x, 0f) * uvSize,
            origin + new Vector2(size.z + size.x, size.y) * uvSize,
            origin + new Vector2(size.z * 2 + size.x, size.y) * uvSize,
            origin + new Vector2(size.z * 2 + size.x, 0f) * uvSize,
            // Right
            origin + new Vector2(size.z, 0f) * uvSize,
            origin + new Vector2(size.z, size.y) * uvSize,
            origin + new Vector2(0f, size.y) * uvSize,
            origin + new Vector2(0f, 0f) * uvSize,
            // Back
            origin + new Vector2((size.z + size.x) * 2f, 0f) * uvSize,
            origin + new Vector2((size.z + size.x) * 2f, size.y) * uvSize,
            origin + new Vector2(size.z * 2 + size.x, size.y) * uvSize,
            origin + new Vector2(size.z * 2 + size.x, 0f) * uvSize,
            // Bottom
            origin + new Vector2(size.z + size.x, size.y) * uvSize,
            origin + new Vector2(size.z + size.x, size.y + size.z) * uvSize,
            origin + new Vector2(size.z + size.x * 2, size.y + size.z) * uvSize,
            origin + new Vector2(size.z + size.x * 2, size.y) * uvSize
        };
    }

    BoneWeight[] GetBoneWetghtArray(int boneIndex) // 버택스 별로 칠하는거다.
    {
        BoneWeight[] newWeights = new BoneWeight[24];
        for(int i= 0; i < newWeights.Length; ++i)
        {
            newWeights[i].boneIndex0 = boneIndex;
            newWeights[i].weight0 = 1f;
        }

        return newWeights;
    }

	// Use this for initialization
	void Start ()
    {
        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();
        Mesh m = new Mesh();

        // Head
        Vector3[] headVArr = GetVertexArray(new Vector3(0f, 1.4f, 0f), new Vector3(2f, 2f, 2f));
        int[] headTArr = GetIndexArray(0);
        Vector2[] headUArr = GetUVArray(new Vector2(0f, 0.75f), new Vector3(2f, 2f, 2f));

        // LHands
        Vector3[] lhandVArr = GetVertexArray(new Vector3(-0.3f, 0.9f, 0f), new Vector3(1f, 3f, 1f));
        int[] lhandTArr = GetIndexArray(24);
        Vector2[] lhandUArr = GetUVArray(new Vector2(0.5f, 0f), new Vector3(1f, 3f, 1f));

        // RHands
        Vector3[] rhandVArr = GetVertexArray(new Vector3(0.3f, 0.9f, 0f), new Vector3(1f, 3f, 1f));
        int[] rhandTArr = GetIndexArray(48);
        Vector2[] rhandUArr = GetUVArray(new Vector2(0.625f, 0.5f), new Vector3(1f, 3f, 1f));

        // Body
        Vector3[] bodyVArr = GetVertexArray(new Vector3(0f, 0.9f, 0f), new Vector3(2f, 3f, 1f));
        int[] bodyTArr = GetIndexArray(72);
        Vector2[] bodyUArr = GetUVArray(new Vector2(0.25f, 0.5f), new Vector3(2f, 3f, 1f));

        // LLeg
        Vector3[] llegVArr = GetVertexArray(new Vector3(-0.1f, 0.3f, 0f), new Vector3(1f, 3f, 1f));
        int[] llegTArr = GetIndexArray(96);
        Vector2[] llegUArr = GetUVArray(new Vector2(0.25f, 0f), new Vector3(1f, 3f, 1f));

        // RLeg
        Vector3[] rlegVArr = GetVertexArray(new Vector3(0.1f, 0.3f, 0f), new Vector3(1f, 3f, 1f));
        int[] rlegTArr = GetIndexArray(120);
        Vector2[] rlegUArr = GetUVArray(new Vector2(0f, 0.5f), new Vector3(1f, 3f, 1f));

        List<Vector3> VerticesList = new List<Vector3>();
        VerticesList.AddRange(headVArr);
        VerticesList.AddRange(lhandVArr);
        VerticesList.AddRange(rhandVArr);
        VerticesList.AddRange(bodyVArr);
        VerticesList.AddRange(llegVArr);
        VerticesList.AddRange(rlegVArr);

        List<int> TriangleList = new List<int>();
        TriangleList.AddRange(headTArr);
        TriangleList.AddRange(lhandTArr);
        TriangleList.AddRange(rhandTArr);
        TriangleList.AddRange(bodyTArr);
        TriangleList.AddRange(llegTArr);
        TriangleList.AddRange(rlegTArr);

        List<Vector2> UVList = new List<Vector2>();
        UVList.AddRange(headUArr);
        UVList.AddRange(lhandUArr);
        UVList.AddRange(rhandUArr);
        UVList.AddRange(bodyUArr);
        UVList.AddRange(llegUArr);
        UVList.AddRange(rlegUArr);

        m.vertices = VerticesList.ToArray();
        m.triangles = TriangleList.ToArray();
        m.uv = UVList.ToArray();
        m.bindposes = new Matrix4x4[]//행렬계산을 미리 해주는 애.  각 본들에 관해서 계산을 해서 기준위치를 미리 계산해두는 애.
        {
            bones[0].worldToLocalMatrix * bones[0].localToWorldMatrix,
            bones[1].worldToLocalMatrix * bones[0].localToWorldMatrix,
            bones[2].worldToLocalMatrix * bones[0].localToWorldMatrix,
            bones[3].worldToLocalMatrix * bones[0].localToWorldMatrix,
            bones[4].worldToLocalMatrix * bones[0].localToWorldMatrix,
            bones[5].worldToLocalMatrix * bones[0].localToWorldMatrix,
            bones[6].worldToLocalMatrix * bones[0].localToWorldMatrix,
        };


        List<BoneWeight> BoneList = new List<BoneWeight>();
        BoneList.AddRange(GetBoneWetghtArray(2));
        BoneList.AddRange(GetBoneWetghtArray(3));
        BoneList.AddRange(GetBoneWetghtArray(4));
        BoneList.AddRange(GetBoneWetghtArray(1));
        BoneList.AddRange(GetBoneWetghtArray(5));
        BoneList.AddRange(GetBoneWetghtArray(6));


        m.boneWeights = BoneList.ToArray();

        smr.sharedMesh = m;
        smr.bones = bones;


        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}