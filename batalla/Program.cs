using System;

namespace Name{
	class Program{

		static String[] tabla={"X","X","X","X","X","|","X","X","X","X","X"};

		static void Main(string[] args){
			tablero("PONER BARCOS");
			ponerbarcos();
			Console.Clear();
			tablero("JUGAR");
			jugar();
			Console.ReadKey();
		}

		static void ponerbarcos(){
			for(int a=1; a<=3; a++){
				Boolean repetir=true;
				do{
					Console.Write("\n\nJugador 1 barco "+a+" (1-5): ");
					int posicion_barco=Int32.Parse(Console.ReadLine());
					if(posicion_barco<=0 || posicion_barco>5 || existebarco(posicion_barco-1)==true){
						repetir=true;
					}else{
						tabla[posicion_barco-1]="O";
						repetir=false;
					}
					Console.Clear();
					tablero("PONER BARCOS");
				}while(repetir==true);
			}
			for(int a=1; a<=3; a++){
				Boolean repetir=true;
				do{
					Console.Write("\n\nJugador 2 barco "+a+" (1-5): ");
					int posicion_barco=Int32.Parse(Console.ReadLine());
					if(posicion_barco<=0 || posicion_barco>5 || existebarco((posicion_barco-1)+6)==true){
						repetir=true;
					}else{
						tabla[(posicion_barco-1)+6]="O";
						repetir=false;
					}
					Console.Clear();
					tablero("PONER BARCOS");
				}while(repetir==true);
			}
		}

		static void jugar(){
			do{
				int posicion_barco=0;
				Console.Write("\n\nTurno del jugador 1 (1-5): ");
				posicion_barco=Int32.Parse(Console.ReadLine());
				if(posicion_barco<=0 || posicion_barco>5){
					Console.Write("\nNo le has dado a un barco");
				}else{
					if(existebarco((posicion_barco-1)+6)==true){
						tabla[(posicion_barco-1)+6]="X";
						Console.Write("\nAtaque exitoso");
					}else{
						Console.Write("\nNo le has dado a un barco");
					}
				}
				if(hayganador()==""){
					Console.ReadKey();
					Console.Clear();
					tablero("JUGAR");
					Console.Write("\n\nTurno del jugador 2 (1-5): ");
					posicion_barco=Int32.Parse(Console.ReadLine());
					if(posicion_barco<=0 || posicion_barco>5){
						Console.Write("\nNo le has dado a un barco");
					}else{
						if(existebarco(posicion_barco-1)==true){
							tabla[posicion_barco-1]="X";
							Console.Write("\nAtaque exitoso");
						}else{
							Console.Write("\nNo le has dado a un barco");
						}
					}
					Console.ReadKey();
				}
				Console.Clear();
				tablero("JUGAR");
			}while(hayganador()=="");
			Console.Write("\nHa ganado el "+hayganador());
		}

		static String hayganador(){
			Boolean jugador1=true;
			Boolean jugador2=true;
			for(int a=0; a<5; a++){
				if(tabla[a]=="O"){
					jugador1=false;
					a=5;
				}
			}
			if(jugador1==true){
				return "Jugador 2";
			}else{
				for(int a=6; a<11; a++){
					if(tabla[a]=="O"){
						jugador2=false;
						a=11;
					}
				}
				if(jugador2==true){
					return "Jugador 1";
				}else{
					return "";
				}
			}
		}

		static Boolean existebarco(int posicion_barco){
			if(tabla[posicion_barco]=="X"){
				return false;
			}else{
				return true;
			}
		}

		static void tablero(String titulo){
			Console.WriteLine(titulo+"\n");
			for(int a=0; a<tabla.Length; a++){
				Console.Write(tabla[a]);
			}
		}

	}
}