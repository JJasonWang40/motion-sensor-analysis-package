stundenSumme <- integer(24)
stundenAnzahlDatensaetze <- integer(24)
stundenDurchschnitt <- integer(24)

for(i in 1:length(datensatz0Daten)) {
	stundenSumme[as.integer(substr(datensatz0Uhrzeit[i], 1, 2)) + 1] = stundenSumme[as.integer(substr(datensatz0Uhrzeit[i], 1, 2)) + 1] + datensatz0Daten[i];
	stundenAnzahlDatensaetze[as.integer(substr(datensatz0Uhrzeit[i], 1, 2)) + 1] = stundenAnzahlDatensaetze[as.integer(substr(datensatz0Uhrzeit[i], 1, 2)) + 1] +1;
}

for (i in 1:24)
{
	stundenDurchschnitt[i] = stundenSumme[i] / stundenAnzahlDatensaetze[i]
}
if (length(dev.list()))
{
	dev.off()
}
jpeg(filename = paste("Output/", datensatz0Name, "_Schritte_DS.jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)
	
#barplot(stundenDurchschnitt, main=paste('Schritte nach Stunden (durchschnitt)\n'), ylab='Schritte', col='gray90', names.arg=0:23, las=2, space=0, lty=2)
barplot(stundenDurchschnitt, main=paste('Schritte nach Stunden (durchschnitt)\n'), ylab='Schritte', col='gray90', names.arg=0:23)
dev.print(device=postscript, paste("Output/Actigraph_", TitelShort, "_Schritte_DS.eps"), onefile=FALSE, horizontal=FALSE)

dev.copy(jpeg, paste("Output/", datensatz0Name, "_Schritte_DS.jpg"))		

dev.off()