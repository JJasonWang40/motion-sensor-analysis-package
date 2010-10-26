ersterDatensatzDesAktuellenTages <- 1

for (j in 1:anzahlTage) {
	aktuellerTag = datensatz0Datum[ersterDatensatzDesAktuellenTages]

	aktuellerDatensatzUhrzeit = c("")
	aktuellerDatensatzDaten = c(0)

	for(i in 1:length(datensatz0Datum)) {
		if (aktuellerTag == datensatz0Datum[i]) {
			aktuellerDatensatzUhrzeit = c(aktuellerDatensatzUhrzeit, datensatz0Uhrzeit[i])
			aktuellerDatensatzDaten = c(aktuellerDatensatzDaten, datensatz0Daten[i])
		}
	}
	if (length(dev.list()))
	{
		dev.off()
	}

	jpeg(filename = paste("Output/", datensatz0Name, "_TagesAuswertung_",aktuellerTag, ".jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)
	
	barplot(aktuellerDatensatzDaten , main=paste("Aktivität am ", aktuellerTag), xlab='Uhrzeit', ylab='Aktivität in vmu', col='gray90', names.arg=aktuellerDatensatzUhrzeit, las=1, space=0)
			
	dev.off()
	
	ersterDatensatzDesAktuellenTages  = ersterDatensatzDesAktuellenTages + length(aktuellerDatensatzDaten)
}