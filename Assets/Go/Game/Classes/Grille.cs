public class Grille{
	private char[,] coord;
	
	public Grille(){
		coord = new char [9, 9];
		for (int i=0; i<9; i++) {
			for(int j=0;j<9;j++){
				coord[i,j]=' ';
			}
		}
	}
	
	public void setValue(int x,int z,char value)
	{
		coord [x, z] = value;
	}
	
	public bool isTaken(int x,int z){
		if (coord [x, z] == 'B')
			return true;
		else if (coord [x, z] == 'N')
			return true;
		else
			return false;
	}
	
	public void isEye(){
	}
	
}