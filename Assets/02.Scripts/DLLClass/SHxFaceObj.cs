public struct SHxFaceObj
{
	public int m_numVtx;
	public int m_numVtxFace;
	public int m_numTex;
	public int m_numTexFace;

	public unsafe SHxVtx* m_pVtxList;
	public unsafe SHxVtx* m_pTexList;
	public unsafe SHxVtx* m_pAniVtxList;
}