public struct SHxFaceObj
{
	public int m_numVtx;
	public int m_numVtxFace;
	public int m_numTex;
	public int m_numTexFace;

	public unsafe SHxVtx* m_pVtxList;
	public unsafe SHxVtx* m_pTexList;
	public unsafe SHxVtx* m_pAniVtxList;

	public int m_FaceID;
	public unsafe SHxVtx** m_pEmotionVtxList;
	public unsafe SHxVtx** m_pPhonemeVtxList;
	public unsafe SHxVtx** m_pExVtxList;
	public int m_numEmotion;
	public int m_numPhoneme;
	
	public unsafe SHxFace* m_pVtxFaceList;
	public unsafe SHxFace* m_pTexFaceList;
}