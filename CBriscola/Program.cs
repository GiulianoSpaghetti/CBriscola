/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 0.1
 *
 *  Created by numerunix on 22/05/22.
 *  Copyright 2022 Some rights reserved.
 *
 */

namespace CBriscola {
	class Program
	{
		private static giocatore g;
		private static giocatore cpu;
		private static giocatore primo;
		private static giocatore secondo;
		private static mazzo m;
		public static System.Resources.ResourceManager mgr;
		public static void Main(String[] args)
		{
			CreaResourceManager(args.Length > 0 ? args[0] : "it");
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
				System.Console.WriteLine($"{mgr.GetString("CartaBriscola")}: {briscola}");
				System.Console.WriteLine($"{mgr.GetString("PuntiCpu")}: {cpu.getPunteggio()}"); ;
				System.Console.WriteLine($"{mgr.GetString("PuntiUtente")}: {g.getPunteggio()}");
				System.Console.WriteLine($"{mgr.GetString("CarteMazzo")}: {m.getNumeroCarte()} {mgr.GetString("carte")}.");
				gioca();
				c = primo.getCartaGiocata();
				c1 = secondo.getCartaGiocata();
				System.Console.WriteLine($" {c} {c1}");

				if ((c.CompareTo(c1) > 0 && c.stessoSeme(c1)) || (c1.stessoSeme(briscola) && !c.stessoSeme(briscola)))
				{
					temp = secondo;
					secondo = primo;
					primo = temp;
				}
				primo.aggiornaPunteggio(secondo);
				if (!aggiungiCarte())
					break;
			}
			Console.Write($"{mgr.GetString("PremereInvio")}");
			Console.ReadLine();
		}

		private static void gioca()
		{
			try
			{
				primo.gioca();
				if (primo == cpu)
					System.Console.WriteLine($"{mgr.GetString("Giocata")} {primo.getCartaGiocata()}");
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
				System.Console.WriteLine($"{mgr.GetString("PartitaFinita")}.");
				System.Console.WriteLine($"{mgr.GetString("PuntiUtente")}: {g.getPunteggio()}");
				System.Console.WriteLine($"{mgr.GetString("PuntiCpu")}: {cpu.getPunteggio()}");
				if (g.getPunteggio() == cpu.getPunteggio())
					Console.WriteLine($"{mgr.GetString("PartitaPatta")}.");
				else
					if (g.getPunteggio() > cpu.getPunteggio())
						Console.WriteLine($"{mgr.GetString("HaiVintoPer")} {g.getPunteggio() - cpu.getPunteggio()} {mgr.GetString("punti")}.");
					else
						Console.WriteLine($"{mgr.GetString("HaiPersoPer")} {cpu.getPunteggio() - g.getPunteggio()} {mgr.GetString("punti")}.");

				return false;
			}
			return true;
		}
		private static void CreaResourceManager(string arg) {
			System.Resources.ResourceManager m;
			m = new System.Resources.ResourceManager($"CBriscola.Strings.{arg}.Resources", System.Reflection.Assembly.GetExecutingAssembly()); try
			{
				m.GetString("di");
			}
			catch (System.Resources.MissingManifestResourceException e)
			{
				m = new System.Resources.ResourceManager($"CBriscola.Strings.it.Resources", System.Reflection.Assembly.GetExecutingAssembly());
			}
			mgr = m;
		}
	}
}