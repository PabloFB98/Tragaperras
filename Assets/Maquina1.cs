using UnityEngine;

public class Maquina1 : MonoBehaviour
{


    // Cambiamos el char a publico para cambiar los valores y facilitar las pruebas.
    public char[] valores = new char[] { 'A', 'B', 'C', 'D' };

    char rodillo1;
    char rodillo2;
    char rodillo3;

    public bool boton = false;

    public float saldo = 1000;

    // Variable pública para que el coste de cada tirada pueda modificarse.
    public int apuesta = 10;

    //Creamos una variable para comprobar si el juego ha terminado.
    bool juegoTerminado = false;

    void Start()
    {
        // Cambiamos un poco la frase de bienvenida.
        print("Bienvenido! Puedes jugar pulsando el botón y cambiar el valor de la apuesta.");
    }

    
    void Update()
    {
        
        // Comprobamos si el juego ha terminado.
        if(juegoTerminado)
        {
            return;
        }
        
        
        if (boton)
        {
            tiraRodillos();
            boton = false;
        }



    }



    private void tiraRodillos()
    {
        
        // Si el jugador se queda sin saldo, la partida termina.
        if(saldo == 0)
        {
            print("Lo siento, no te queda saldo.");
            juegoTerminado = true;
            return;
        }
        
        
        // En caso de tener menos saldo que coste introducido no se puede tirar.
        if (saldo < apuesta)
        {


            print("No tienes saldo suficiente.");
            return;
        }


        saldo = saldo - apuesta;





        // Eliminamos el "-1" ya que de esta manera nunca aparece el último valor del char.
        rodillo1 = valores[Random.Range(0, valores.Length)];
        rodillo2 = valores[Random.Range(0, valores.Length)];
        rodillo3 = valores[Random.Range(0, valores.Length)];


        print(rodillo1.ToString() + ',' + rodillo2.ToString() + ',' + rodillo3.ToString());

        if (rodillo1 == rodillo2 && rodillo1 == rodillo3)
        {

            // Cambiamos la recompensa, ya que si la multiplicamos por 0.9 perderia saldo.
            print("Premio!! ganaste: " + (apuesta * 5) + " €");
            saldo = saldo + apuesta * 5;
            print("Su saldo es de: " + saldo + " €");
        }
        else
        {
            print("No has tenido suerte... saldo disponible " + saldo + " €");
        }


    }


}