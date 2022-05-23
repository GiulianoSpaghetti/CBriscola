/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 0.1
 *
 *  Created by numerunix on 22/05/22.
 *  Copyright 2022 Some rights reserved.
 *
 */

using System;
class giocatore {
	private string nome;
	private carta[] mano;
	private bool ordinaMano;
	private UInt16 numeroCarte;
	private UInt16 iCartaGiocata;
	private UInt16 punteggio;
	private giocatoreHelper helper;
	public enum CARTA_GIOCATA {NESSUNA_CARTA_GIOCATA=UInt16.MaxValue};
	public giocatore(giocatoreHelper h, string n, UInt16 carte, bool ordina=true) {
        ordinaMano=ordina;
        numeroCarte=carte;
         iCartaGiocata=(UInt16) (CARTA_GIOCATA.NESSUNA_CARTA_GIOCATA);
         punteggio=0;
	    helper=h;
	    nome=n;
        mano=new carta[3];
    }
	public string getNome() {return nome;}
	public void setNome(string n) {nome=n;}
	public bool getFlagOrdina() {return ordinaMano;}
	public void setFlagOrdina(bool ordina) {ordinaMano=ordina;}
	public void addCarta(mazzo m){
	    if (mano.Length==numeroCarte && iCartaGiocata==(UInt16) CARTA_GIOCATA.NESSUNA_CARTA_GIOCATA)
		    throw new ArgumentException($"Chiamato giocatore::setCarta con mano.size()==numeroCarte=={numeroCarte}");
	    carta c;
	    if (iCartaGiocata!=(UInt16) CARTA_GIOCATA.NESSUNA_CARTA_GIOCATA) {
	        try {
		        mano[iCartaGiocata]=carta.getCarta(m.getCarta());
	        } catch (IndexOutOfRangeException e) {
		        numeroCarte--;
		        return;
            }
            iCartaGiocata=(UInt16) CARTA_GIOCATA.NESSUNA_CARTA_GIOCATA;
            return;
	    }
	    try {
		    c=carta.getCarta(m.getCarta());
	    } catch (IndexOutOfRangeException e) {
		numeroCarte--;
		return;
		}	

	}
	public carta getCartaGiocata() {
		return mano[iCartaGiocata];
	}
	public UInt16 getPunteggio() {return punteggio;}
	public void gioca() {
		iCartaGiocata=helper.gioca(mano);
	}
	public void gioca(giocatore g1) {
				iCartaGiocata=helper.gioca(mano, g1.getCartaGiocata());
	}
	public void aggiornaPunteggio(giocatore g) {
		helper.aggiornaPunteggio(ref punteggio, getCartaGiocata(), g.getCartaGiocata());
	}

}