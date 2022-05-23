/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 0.1
 *
 *  Created by numerunix on 22/05/22.
 *  Copyright 2022 Some rights reserved.
 *
 */


using System;

class carta {
	private UInt16 seme,
			   valore,
			   punteggio;
	private string semeStr;
	private cartaHelper helper;
    private static carta[] carte=new carta[40];
    private carta(UInt16 n, cartaHelper h) {
        helper=h;
        seme=helper.getSeme(n);
	    valore=helper.getValore(n);
	    punteggio=helper.getPunteggio(n);
	    semeStr=helper.getSemeStr(n);
    }		
	public void inizializza(UInt16 n, cartaHelper h) {
	    for (UInt16 i=0; i<n; i++) {
		    carte[i]=new carta(i,h);
	    }
    }		
    public static carta getCarta(UInt16 quale) {return carte[quale];}
    public UInt16 getSeme() {return seme;}
    public UInt16 getValore() {return valore;}
	public UInt16 getPunteggio() {return punteggio;}
	public string getSemeStr() {return semeStr;}
	public bool stessoSeme(carta c1) {return seme==c1.getSeme();}
	public bool minore(carta c1) {
        return helper.compara(helper.getNumero(getSeme(), getValore()), helper.getNumero(c1.getSeme(),c1.getValore()))==cartaHelper.RISULTATI_COMPARAZIONE.MAGGIORE_LA_SECONDA;

    }
}