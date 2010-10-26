
for (i in 1:((length(datensatz0Daten) / numberOfDatasets) + 1)) {
	if (length(dev.list()))
	{
		dev.off()
	}
	
	jpeg(filename = paste("Output/", datensatz0Name, "_", datensatz1Name, "_Scatter_Dataset_",startDataset, "-", (startDataset + numberOfDatasets), ".jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)
	plot(datensatz0Daten[startDataset:(startDataset + numberOfDatasets)], datensatz1Daten[startDataset:(startDataset + numberOfDatasets)], type='p', main=paste("Scatter Graph for dataset ", startDataset, " - ", (startDataset + numberOfDatasets), "\r\n", datensatz0Datum[startDataset], " ", datensatz0Uhrzeit[startDataset], " - ", datensatz0Datum[(startDataset + numberOfDatasets)], " ", datensatz0Uhrzeit[(startDataset + numberOfDatasets)]), xlab=datensatz0Name, ylab=datensatz1Name, col='gray20')
			
	dev.off()
	
	startDataset = numberOfDatasets * i
}