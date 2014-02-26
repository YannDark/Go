public enum couleur{
	Blanche,
	Noire,
	PriseNoire,
	PriseBlanche,
	Indefinie
};

public struct coordonnees{
	public int x;
	public int y;
};

public enum etat{
	nonPosee,
	posee,
	morte
}

public struct influences{
	public float influenceNoire;
	public float influenceBlanche;

};
