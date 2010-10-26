ersterDatensatzDesAktuellenTages = 1
tage = vector(mode = "logical", length = 0)
tagesSchnitte = vector(mode = "logical", length = 0)

for (j in 1:anzahlTage) {
	aktuellerTag = datensatz0Datum[ersterDatensatzDesAktuellenTages]
	tage = c(tage, aktuellerTag)
	
	aktuellerDatensatzUhrzeit = vector(mode = "logical", length = 0);
	aktuellerDatensatzSumme = 0
	aktuellerDatensatzAnzahl = 0
	aktuellerDatensatzDurchschnitt = 0

	for(i in 1:length(datensatz0Datum)) {
		if (aktuellerTag == datensatz0Datum[i]) {
			aktuellerDatensatzUhrzeit = c(aktuellerDatensatzUhrzeit, datensatz0Uhrzeit[i])
			if (datensatz0Daten[i] < 5) {
				datensatz0Daten[i] = 0
			}
			aktuellerDatensatzAnzahl = aktuellerDatensatzAnzahl + 1
			aktuellerDatensatzSumme = aktuellerDatensatzSumme + datensatz0Daten[i]
		}
	}
	aktuellerDatensatzDurchschnitt = aktuellerDatensatzSumme / aktuellerDatensatzAnzahl
	tagesSchnitte = c(tagesSchnitte, aktuellerDatensatzDurchschnitt)

	ersterDatensatzDesAktuellenTages  = ersterDatensatzDesAktuellenTages + aktuellerDatensatzAnzahl
}

if (length(dev.list()))
{
	dev.off()
}
jpeg(filename = paste("Output/", datensatz0Name, "_Tagesschnitt.jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)

barplot(tagesSchnitte , main=paste("Tages-Durchschnittsaktivität zwischen dem\r\n", datensatz0Datum[1], " und dem ", datensatz0Datum[ersterDatensatzDesAktuellenTages]), ylab='Aktivität in vmu', col='gray90', names.arg=tage, las=2, space=0)
		
dev.off()
