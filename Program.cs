using System;
using System.Security.Cryptography.X509Certificates;

//1 cooperar, 2 trair

public class Robo
{
    public int traiu = 0;
    public int colaborou = 0;
    public int DecisaoR { get; set; }
    public Robo(int decisaoR)
    {
        DecisaoR = decisaoR;

    }

    public void Decisao(int decisaoAnterior)
    {
       

        if (traiu == 2 | colaborou == 5)
        {
            DecisaoR = 2;
            traiu = 0;
            colaborou = 3;
        }
        else if (decisaoAnterior == 0)
        {
            DecisaoR = 1;
        }
        else if (decisaoAnterior == 1)
        {
            colaborou += 1;
            DecisaoR = 1;
        }
        else if (decisaoAnterior == 2)
        {
            traiu += 1;
            DecisaoR = 2;
        }

        
    }
}

public class Principal
{
    public static void Main()
    {
        int decisaoAnterior = 0; 
        int pontosJogador = 0;
        int pontosRobo = 0;
        int rodada = 0;

        Robo roboFilho = new Robo(0);
        while (rodada <10)
        {
           
            Console.WriteLine("Digite 1-cooperar 2-trair");
            int decisaojogador = int.Parse(Console.ReadLine());
            roboFilho.Decisao(decisaoAnterior);

            if (decisaojogador == 1 && roboFilho.DecisaoR == 1)
            {
                pontosJogador+= 5; pontosRobo+=5;
                Console.WriteLine("Os dois colaboraram ambos ganham 1 ponto");
            }
            else if (decisaojogador < roboFilho.DecisaoR)
            {
                pontosRobo += 2;
                Console.WriteLine("O robo traiu, ganha dois pontos");
            }
            else if (decisaojogador > roboFilho.DecisaoR)
            {
                pontosJogador += 2;
                Console.WriteLine("Você traiu o robo, ganhou dois pontos");
            }
            else if (decisaojogador == 2 && roboFilho.DecisaoR == 2)
            {
                pontosJogador -= 3; pontosRobo -= 3;
                Console.WriteLine("Ambos trairam, perdem 2");
            }
            decisaoAnterior = decisaojogador;
            Console.WriteLine($"Pontos Robo: {pontosRobo}\nPontos jogador: {pontosJogador}\n");
            rodada++;
        }
        Console.WriteLine($"--------------------\nPontos Robo: {pontosRobo}\nPontos jogador: {pontosJogador} ");


        //        roboFilho.Decisao(decisaojogador);
        //        Console.WriteLine(roboFilho.DecisaoR);

    }
}