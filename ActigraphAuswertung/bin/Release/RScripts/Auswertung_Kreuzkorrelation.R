
if (length(dev.list()))
{
	dev.off()
}

print(paste("length(datensatz0Daten) = ", length(datensatz0Daten), "    length(datensatz1Daten) = ", length(datensatz1Daten)))

jpeg(filename = paste(outputFolder, outputPrefix, datensatz0Name, "-", datensatz1Name, "_Kreuzkorrelation.jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)
correlation <- ccf(datensatz0Daten, datensatz1Daten, type = "correlation", plot=TRUE, main=paste("Kreuzkorrelation zwischen \r\n", datensatz0Name, " und ", datensatz1Name ))

dev.off();