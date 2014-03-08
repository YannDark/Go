using UnityEngine;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

public class ConnectionBDD {
	
	//Variables
	private MySqlConnection connection;
	private string server;
	private string database;
	private string uid;
	private string password;
	
	//Constructor
	public ConnectionBDD()
	{
		Initialize();
	}
	
	//Initialize values
	private void Initialize()
	{
		server = "localhost"; //"labo.nantes.epsi.fr";
		database = "goban";
		uid = "root"; //"Epsi5";
		password = ""; //"ProjetJeuDeGo";
		string connectionString;
		connectionString = "server=" + server + ";" + "database=" + database + ";" + "uid=" + uid + ";" + "password=" + password + ";";
		connection = new MySqlConnection(connectionString);
	}
	
	/// <summary>
	/// Open connection to database
	/// </summary>
	/// <returns><c>true</c>, if connection was opened, <c>false</c> otherwise.</returns>
	private bool OpenConnection()
	{
		try
		{
			connection.Open();
			return true;
		}
		catch (MySqlException e)
		{
			switch (e.Number)
			{
			case 0:
				Debug.Log("Connexion momentanément impossible. Veuillez rééssayer.");
				break;
				
			case 1045:
				Debug.Log("Login ou mot de passe invalide. Veuillez rééssayer.");
				break;
			}
			return false;
		}
	}
	
	/// <summary>
	/// Closes the connection.
	/// </summary>
	/// <returns><c>true</c>, if connection was closed, <c>false</c> otherwise.</returns>
	private bool CloseConnection()
	{
		try
		{
			connection.Close();
			return true;
		}
		catch (MySqlException e)
		{
			Debug.Log(e.Message);
			return false;
		}
	}
	
	/// <summary>
	/// Inserts data into table Goban.
	/// </summary>
	/// <param name="idGoban">Identifier goban.</param>
	/// <param name="idPartie">Identifier partie.</param>
	/// <param name="numeroCoup">Numero coup.</param>
	/// <param name="natureCoup">Nature coup.</param>
	/// <returns><c>true</c>, if insert successful, <c>false</c> otherwise.</returns>
	public bool InsertGoban(int idPartie, int numeroCoup, string natureCoup, int joueurEnCours)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "INSERT INTO goban (idPartie, numeroCoup, natureCoup, joueurEnCours) VALUES (@idPartie, @numeroCoup, @natureCoup, @joueurEnCours)";
		query.Parameters.AddWithValue( "@idPartie", idPartie );
		query.Parameters.AddWithValue( "@numeroCoup", numeroCoup );
		query.Parameters.AddWithValue( "@natureCoup", natureCoup );
		query.Parameters.AddWithValue( "@joueurEnCours", joueurEnCours );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Inserts data into table Joueur.
	/// </summary>
	/// <param name="idJoueur">Identifier joueur.</param>
	/// <param name="nom">Nom.</param>
	/// <returns><c>true</c>, if insert successful, <c>false</c> otherwise.</returns>
	public bool InsertJoueur(string nom)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "INSERT INTO joueurs (nom) VALUES (@nom)";
		query.Parameters.AddWithValue( "@nom", nom );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Inserts data into table Partie.
	/// </summary>
	/// <param name="idPartie">Identifier partie.</param>
	/// <param name="idJoueurNoir">Identifier joueur noir.</param>
	/// <param name="idJoueurBlanc">Identifier joueur blanc.</param>
	/// <param name="etatPartie">Etat partie.</param>
	/// <param name="heureDebut">Heure debut.</param>
	/// <param name="heureFin">Heure fin.</param>
	/// <returns><c>true</c>, if insert successful, <c>false</c> otherwise.</returns>
	public bool InsertPartie(int idJoueurNoir)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "INSERT INTO partie (idJoueurNoir, etatPartie) VALUES (@idJoueurNoir , @etatPartie);";
		query.Parameters.AddWithValue( "@idJoueurNoir", idJoueurNoir );
		query.Parameters.AddWithValue( "@etatPartie", "En cours" );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Inserts data into table Pion.
	/// </summary>
	/// <param name="idPartie">Identifier pion.</param>
	/// <param name="idJoueurNoir">Identifier goban.</param>
	/// <param name="idJoueurBlanc">Position X</param>
	/// <param name="etatPartie">Position Y</param>
	/// <param name="heureDebut">Colonne du pion</param>
	/// <param name="heureFin">Etat du pion</param>
	/// <returns><c>true</c>, if insert successful, <c>false</c> otherwise.</returns>
	public bool InsertPion(int idGoban, int positionX, int positionY, string pioncol, string etatPion)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "INSERT INTO pion (idGoban, positionX, positionY, pioncol, etatPion) VALUES (@idGoban ,@positionX, @positionY, @pioncol, @etatPion)";
		query.Parameters.AddWithValue( "@idGoban", idGoban );
		query.Parameters.AddWithValue( "@positionX", positionX );
		query.Parameters.AddWithValue( "@positionY", positionY );
		query.Parameters.AddWithValue( "@pioncol", pioncol );
		query.Parameters.AddWithValue( "@etatPion", etatPion );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Updates table goban by I.
	/// </summary>
	/// <param name="idGoban">Identifier goban.</param>
	/// <param name="idPartie">Identifier partie.</param>
	/// <param name="numeroCoup">Numero coup.</param>
	/// <param name="natureCoup">Nature coup.</param>
	/// <returns><c>true</c>, if update successful, <c>false</c> otherwise.</returns>
	public bool UpdateGobanByID(int idGoban, int idPartie, int numeroCoup, string natureCoup, int joueurEnCours)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "UPDATE goban SET idPartie=@idPartie, numeroCoup=@numeroCoup, natureCoup=@natureCoup, joueurEnCOurs=@joueurEnCours WHERE idGoban=@idGoban";
		query.Parameters.AddWithValue( "@idGoban", idGoban );
		query.Parameters.AddWithValue( "@idPartie", idPartie );
		query.Parameters.AddWithValue( "@numeroCoup", numeroCoup );
		query.Parameters.AddWithValue( "@natureCoup", natureCoup );
		query.Parameters.AddWithValue( "@joueurEnCours", joueurEnCours );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Updates table Joueurs by I.
	/// </summary>
	/// <param name="idJoueur">Identifier joueur.</param>
	/// <param name="nom">Nom.</param>
	/// <returns><c>true</c>, if update successful, <c>false</c> otherwise.</returns>
	public bool UpdateJoueursByID(int idJoueur, string nom)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "UPDATE joueurs SET nom=@nom WHERE idJoueur=@idJoueur";
		query.Parameters.AddWithValue( "@idJoueur", idJoueur );
		query.Parameters.AddWithValue( "@nom", nom );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Updates table Partie by I.
	/// </summary>
	/// <param name="idPartie">Identifier partie.</param>
	/// <param name="idJoueurNoir">Identifier joueur noir.</param>
	/// <param name="idJoueurBlanc">Identifier joueur blanc.</param>
	/// <param name="etatPartie">Etat partie.</param>
	/// <param name="heureDebut">Heure debut.</param>
	/// <param name="heureFin">Heure fin.</param>
	/// <returns><c>true</c>, if update successful, <c>false</c> otherwise.</returns>
	public bool UpdatePartieByID(int idPartie, int idJoueurNoir, int idJoueurBlanc, string etatPartie, DateTime heureDebut, DateTime heureFin)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "UPDATE partie SET idJoueurNoir=@idJoueurNoir, idJoueurBlanc=@idJoueurBlanc, etatPartie=@etatPartie, heureDebut=@heureDebut, heureFin=@heureFin WHERE idPartie=@idPartie";
		query.Parameters.AddWithValue( "@idPartie", idPartie );
		query.Parameters.AddWithValue( "@idJoueurNoir", idJoueurNoir );
		query.Parameters.AddWithValue( "@idJoueurBlanc", idJoueurBlanc );
		query.Parameters.AddWithValue( "@etatPartie", etatPartie );
		query.Parameters.AddWithValue( "@heureDebut", heureDebut );
		query.Parameters.AddWithValue( "@heureFin", heureFin );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Updates table Pion by I.
	/// </summary>
	/// <param name="idPion">Identifier pion.</param>
	/// <param name="idGoban">Identifier goban.</param>
	/// <param name="positionX">Position x.</param>
	/// <param name="positionY">Position y.</param>
	/// <param name="pioncol">Pioncol.</param>
	/// <param name="etatPion">Etat pion.</param>
	/// <returns><c>true</c>, if update successful, <c>false</c> otherwise.</returns>
	public bool UpdatePionByID(int idPion, int idGoban, int positionX, int positionY, string pioncol, string etatPion)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "UPDATE pion SET idGoban=@idGoban, positionX=@positionX, positionY=@positionY, pioncol=@pioncol, etatPion=@etatPion WHERE idPion=@idPion";
		query.Parameters.AddWithValue( "@idPion", idPion );
		query.Parameters.AddWithValue( "@idGoban", idGoban );
		query.Parameters.AddWithValue( "@positionX", positionX );
		query.Parameters.AddWithValue( "@positionY", positionY );
		query.Parameters.AddWithValue( "@pioncol", pioncol );
		query.Parameters.AddWithValue( "@etatPion", etatPion );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Deletes table Goban by identifier.
	/// </summary>
	/// <param name="idGoban">Identifier goban.</param>
	/// <returns><c>true</c>, if delete successful, <c>false</c> otherwise.</returns>
	public bool DeleteGobanById(int idGoban)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "DELETE FROM goban WHERE idGoban=@idGoban";
		query.Parameters.AddWithValue( "@idGoban", idGoban );
		
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Deletes table Joueurs by identifier.
	/// </summary>
	/// <param name="idJoueur">Identifier joueur.</param>
	/// <returns><c>true</c>, if delete successful, <c>false</c> otherwise.</returns>
	public bool DeleteJoueursById(int idJoueur)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "DELETE FROM joueurs WHERE idJoueur=@idJoueur";
		query.Parameters.AddWithValue( "@idJoueur", idJoueur );
		
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Deletes table Partie by identifier.
	/// </summary>
	/// <param name="idPartie">Identifier partie.</param>
	/// <returns><c>true</c>, if delete successful, <c>false</c> otherwise.</returns>
	public bool DeletePartieById(int idPartie)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "DELETE FROM partie WHERE idPartie=@idPartie";
		query.Parameters.AddWithValue( "@idPartie", idPartie );
		
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}
	
	/// <summary>
	/// Deletes table Pion by identifier.
	/// </summary>
	/// <param name="idPion">Identifier pion.</param>
	/// <returns><c>true</c>, if delete successful, <c>false</c> otherwise.</returns>
	public bool DeletePionById(int idPion)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "DELETE FROM pion WHERE idPion=@idPion";
		query.Parameters.AddWithValue( "@idPion", idPion );
		
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}

	public string GetPseudoWithIdPartie(int idPartie)
	{
		if (this.OpenConnection())
		{
			using (MySqlCommand cmd = new MySqlCommand("SELECT j.nom FROM goban.Partie p JOIN goban.Joueurs j ON p.idJoueurNoir = j.idJoueur WHERE idPartie = @idPartie;", connection))
			{
				cmd.Parameters.AddWithValue("@idPartie", idPartie);
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					StringBuilder sb = new StringBuilder();
					reader.Read();
					sb.Append(reader.GetString(0).ToString());
					
					return sb.ToString();
				}
			}
		}
		return "";
	}

	public int getIdJoueurWithPseudo(string pseudo)
	{
		if (this.OpenConnection())
		{
			using (MySqlCommand cmd = new MySqlCommand("SELECT idJoueur, nom FROM goban.Joueurs WHERE nom = @nom;", connection))
			{
				cmd.Parameters.AddWithValue("@nom", pseudo);
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					int cpt = 0;
					StringBuilder sb = new StringBuilder();
					while(reader.Read())
					{
						cpt++;
						sb.Append(reader.GetInt32(0));
					}
					this.CloseConnection();
					if (cpt == 0)
						return 0;
					else
						return int.Parse(sb.ToString());
				}
			}

		}
		return 0;
	}

	public int getLastIdJoueurInserted()
	{
		if (this.OpenConnection())
		{
			using (MySqlCommand cmd = new MySqlCommand("select max(idJoueur) from goban.Joueurs;",connection))
			{
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					StringBuilder sb = new StringBuilder();
					reader.Read();
					sb.Append(reader.GetInt32(0));
					this.CloseConnection();
					return int.Parse(sb.ToString());
				}
			}

		}
		return 0;
	}

	public bool joinGame(int idPartie, int idJoueurBlanc)
	{
		bool response = false;
		MySqlCommand query = connection.CreateCommand();
		
		query.CommandText = "UPDATE partie SET idJoueurBlanc=@idJoueurBlanc, heureDebut=@heureDebut WHERE idPartie=@idPartie";
		query.Parameters.AddWithValue( "@idPartie", idPartie );
		query.Parameters.AddWithValue( "@heureDebut", System.DateTime.Now);
		query.Parameters.AddWithValue( "@idJoueurBlanc", idJoueurBlanc );
		
		//open connection
		if (this.OpenConnection())
		{
			query.Connection = connection;
			
			try
			{
				//Execute command
				query.ExecuteNonQuery();
				//close connection
				this.CloseConnection();
				response = true;
			}
			catch (MySqlException e)
			{
				Debug.Log(e.Message);
				//close connection
				this.CloseConnection();
			}
		}
		return response;
	}

	public bool isPartieFull(int idPartie)
	{
		if (this.OpenConnection())
		{
			using (MySqlCommand cmd = new MySqlCommand("select idJoueurBlanc from goban.partie WHERE idPartie=@idPartie AND idJoueurBlanc IS NOT NULL;",connection))
			{
				cmd.Parameters.AddWithValue( "@idPartie", idPartie );
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					int cpt = 0;
					StringBuilder sb = new StringBuilder();
					while(reader.Read())
					{
						cpt++;
						sb.Append(reader.GetInt32(0));
					}
					this.CloseConnection();
					if (cpt == 0)
						return false;
					else
						return true;
				}
			}
			
		}
		return false;
	}


}