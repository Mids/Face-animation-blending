public struct SHxVtx
{
	// Default values are 0 for all
	public float x, y, z; // vertex position
	public float nx, ny, nz; // vertex normal
	public float cx, cy, cz; // vertex color

	// For segmenataion results
	public float mouthS;
	public float leftUpperS;
	public float leftEyeS;
	public float rightUpperS;
	public float rightEyeS;

//	public static SHxVtx operator+(SHxVtx left, SHxVtx right)
//	{
//		left.x += right.x;
//		left.y += right.y;
//		left.z += right.z;
//		left.nx += right.nx;
//		left.ny += right.ny;
//		left.nz += right.nz;
//		return left;
//	}
}