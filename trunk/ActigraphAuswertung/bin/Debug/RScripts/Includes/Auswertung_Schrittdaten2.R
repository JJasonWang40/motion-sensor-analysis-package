ersterDatensatzDesAktuellenTages = 1
tage = vector(mode = "logical", length = 0)
tagesSchritte = vector(mode = "logical", length = 0)

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
	tagesSchritte = c(tagesSchritte, aktuellerDatensatzSumme)

	ersterDatensatzDesAktuellenTages  = ersterDatensatzDesAktuellenTages + aktuellerDatensatzAnzahl
}

if (length(dev.list()))
{
	dev.off()
}
jpeg(filename = paste("Output/", datensatz0Name, "_Schritte.jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)

barplot(tagesSchritte , main=paste("Schritte nach Tag\n", datensatz0Datum[1], " bis ", datensatz0Datum[ersterDatensatzDesAktuellenTages]), ylab='Schritte', col='gray90', names.arg=tage, las=2, space=0)
dev.copy(jpeg, paste("Output/", datensatz0Name, "_Schritte.jpg"))


dev.off()