/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 0.1
 *
 *  Created by numerunix on 22/05/22.
 *  Copyright 2022 Some rights reserved.
 *
 */
 
 using System;

interface cartaHelper {
	public enum RISULTATI_COMPARAZIONE {UGUALI, MAGGIORE_LA_PRIMA=1, MAGGIORE_LA_SECONDA=2};
	public abstract UInt16 getSeme(UInt16 carta);
	public abstract UInt16 getValore(UInt16 carta);
	public abstract UInt16 getPunteggio(UInt16 carta);
	public abstract string getSemeStr(UInt16 carta);
	public abstract UInt16 getNumero(UInt16 seme, UInt16 valore);
	public abstract RISULTATI_COMPARAZIONE compara(UInt16 carta, UInt16 carta1);
};
