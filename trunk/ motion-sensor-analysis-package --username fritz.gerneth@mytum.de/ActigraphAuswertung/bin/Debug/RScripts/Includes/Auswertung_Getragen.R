source('RScripts/Includes/Filter_NotWorn.R')

stundenSumme <- integer(24)
stundenAnzahlDatensaetze <- integer(24)

for(i in 1:length(datensatz0Datum)) {
	stundenSumme[as.integer(substr(datensatz0Uhrzeit[i], 1, 2)) + 1] = stundenSumme[as.integer(substr(datensatz0Uhrzeit[i], 1, 2)) + 1] + worn[i];
	stundenAnzahlDatensaetze[as.integer(substr(datensatz0Uhrzeit[i], 1, 2)) + 1] = stundenAnzahlDatensaetze[as.integer(substr(datensatz0Uhrzeit[i], 1, 2)) + 1] + 1
}
if (length(dev.list()))
{
	dev.off()
}
jpeg(filename = paste("Output/", datensatz0Name, "_Getragen.jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)

barplot(stundenSumme, main=paste('Sensor ', datensatz0Name, ' wurde insgesamt getragen'), ylab='# getragen', col='gray90', names.arg=0:23, las=2, space=0)

dev.off()