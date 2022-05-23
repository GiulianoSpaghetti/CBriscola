/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 0.1
 *
 *  Created by numerunix on 22/05/22.
 *  Copyright 2022 Some rights reserved.
 *
 */
class Program
{
	private static giocatore g;
	private static giocatore cpu;
	private static giocatore primo;
	private static giocatore secondo;
	private static mazzo m;
	public static void Main(String[] args)
	{
		elaboratoreCarteBriscola e = new elaboratoreCarteBriscola();
		m = new mazzo(e);
		carta.inizializza(40, cartaHelperBriscola.getIstanza(e));
		g = new giocatore(new giocatoreHelperUtente(), "Giulio", 3);
		cpu = new giocatore(new giocatoreHelperCpu(elaboratoreCarteBriscola.getCartaBriscola()), "Cpu", 3);
		primo = g;
		secondo = cpu;
		giocatore temp = g;
		carta c;
		carta c1;
		carta briscola = carta.getCarta(elaboratoreCarteBriscola.getCartaBriscola());
		for (UInt16 i = 0; i < 3; i++)
		{
			g.addCarta(m);
			cpu.addCarta(m);
		}
		while (true)
		{
			System.Console.WriteLine($"La carta di briscola è {briscola}");
			System.Console.WriteLine($"Punti del computer: {cpu.getPunteggio()}"); ;
			System.Console.WriteLine($"Punti tuoi:  {g.getPunteggio()}");
			System.Console.WriteLine($"Nel mazzo ci sono {m.getNumeroCarte()} carte.");
			gioca();
			c = primo.getCartaGiocata();
			c1 = secondo.getCartaGiocata();
			System.Console.WriteLine($" {c} {c1}");

			if ((c.minore(c1) && c.stessoSeme(c1)) || (c1.stessoSeme(briscola) && !c.stessoSeme(briscola)))
			{
				temp = secondo;
				secondo = primo;
				primo = temp;
			}
			primo.aggiornaPunteggio(secondo);
			if (!aggiungiCarte())
				break;
		}
	}

	private static void gioca()
    {
		try
		{
			primo.gioca();
			if (primo == cpu)
				System.Console.WriteLine($"Giocata carta ${primo.getCartaGiocata()}");
			secondo.gioca(primo);
		}
		catch (System.ArgumentNullException e)
		{
		}

	}

	private static bool aggiungiCarte()
    {	
		try
		{
			primo.addCarta(m);
			secondo.addCarta(m);
		}
		catch (IndexOutOfRangeException e)
		{
			System.Console.WriteLine($"La partita è finita.");
			System.Console.WriteLine($"Punti tuoi: {g.getPunteggio()}");
			System.Console.WriteLine($"Punti del computer: {cpu.getPunteggio()}");
			return false;
		}
		return true;
	}
}