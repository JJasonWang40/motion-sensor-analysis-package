#data(stat500)
#stat500 <- data.frame(scale(stat500))
#plot(final ˜ midterm,stat500)
#abline(0,1)

ersterDatensatzDesAktuellenTages <- 1

for (j in 1:anzahlTage) {
	aktuellerTag = datensatz0Datum[ersterDatensatzDesAktuellenTages]

	aktuellerDatensatzUhrzeit = c("")
	aktuellerDatensatz0Daten = c(0)
	aktuellerDatensatz1Daten = c(0)

	for(i in 1:length(datensatz0Datum)) {
		if (aktuellerTag == datensatz0Datum[i]) {
			aktuellerDatensatzUhrzeit = c(aktuellerDatensatzUhrzeit, datensatz0Uhrzeit[i])
			aktuellerDatensatz0Daten = c(aktuellerDatensatz0Daten, datensatz0Daten[i])
			aktuellerDatensatz1Daten = c(aktuellerDatensatz1Daten, datensatz1Daten[i])
		}
	}
	
	ersterDatensatzDesAktuellenTages  = ersterDatensatzDesAktuellenTages + length(aktuellerDatensatz0Daten)
	
	if (length(dev.list()))
	{
		dev.off()
	}
	print(paste("length(datensatz0Daten) = ", length(datensatz0Daten), "    length(datensatz1Daten) = ", length(datensatz1Daten)))

	jpeg(filename = paste("Output/", datensatz0Name, "-", datensatz1Name, "_Linear_", aktuellerTag, "_Regression.jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)
	fm <- lm(aktuellerDatensatz0Daten ~ aktuellerDatensatz1Daten)
	plot(aktuellerDatensatz0Daten, aktuellerDatensatz1Daten, pch = 19, main=paste("Regression zwischen ", datensatz0Name, " und ", datensatz1Name, " am ", aktuellerTag))
	abline(fm, col = "red")
	dev.off();
	
	jpeg(filename = paste("Output/", datensatz0Name, "-", datensatz1Name, "_Linear_", aktuellerTag, "_Residuen.jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)
	plot(1:length(residuals(fm)), residuals(fm), main=paste("Residuen zwischen ", datensatz0Name, " und ", datensatz1Name, " am ", aktuellerTag))
	dev.off();
}