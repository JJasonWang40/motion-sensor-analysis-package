
start = 1


for(i in 1:anzahlTage) {

	set = c(FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE, FALSE)
	count = 0
	sum = 0
	hourVal = vector(mode = "logical", length = 24)
	averages = vector(mode = "logical", length = 0)
	
	aktuellerTag = datensatz0Datum[start]
	prevHour = as.integer(substr(datensatz0Uhrzeit[start], 1, 2))
	
	for(i in start:length(datensatz0Datum)) {
		
		hour = as.integer(substr(datensatz0Uhrzeit[i], 1, 2))
		
		if(aktuellerTag == datensatz0Datum[i]) {
		
			set[hour+1] = TRUE
			
			if(hour == prevHour) {
				if(count == 5) {
					averages = c(averages,sum/count)
					count = 1
					sum = datensatz0Daten[i]
				} else {
					sum = sum + datensatz0Daten[i]
					count = count + 1
				}
			} else {
				averages = c(averages,sum/count)
				sum = datensatz0Daten[i]
				count = 1
				hourVal[prevHour+1] = list(averages)
				averages = vector(mode = "logical", length=0)
				prevHour = hour
			}
			
		} else {
			averages = c(averages,sum/count)
			hourVal[prevHour+1] = list(averages)
			averages = vector(mode = "logical", length=0)
			start <- i
			count <- 0
			sum <- 0
			break
		}
	}
	

	sedentary <- integer(24)
	light <- integer(24)
	moderate <- integer(24)
	heavy <- integer(24)
	
	for(j in 1:24) {
		sedentary[j] = 0
		light[j] = 0
		moderate[j] = 0
		heavy[j] = 0
		
		for(k in 1:length(hourVal[[j]])) {
			if(hourVal[[j]][k] < sed) {
				sedentary[j] = sedentary[j] + 1
			} else {
				
				if(hourVal[[j]][k] < lgt) {
					light[j] = light[j] +1
				} else {
					
					if(hourVal[[j]][k] < mod) {
						moderate[j] = moderate[j] +1
					} else {
						
						heavy[j] = heavy[j] +1
					}
				}
			}
			
			
		}
	}
	
	matrixVal = vector(mode = "logical", length = 0)
	
	
	for(j in 1:24) {
		if(!set[j]) {
			sedentary[j] = 0
			light[j] = 0
			moderate[j] = 0
			heavy[j] = 0
		}
	}
	
	matrixVal = c(matrixVal,sedentary,light,moderate,heavy)
	
	tabledData <- matrix(matrixVal, ncol=24, byrow=TRUE)
	
	if (length(dev.list()))
	{
		dev.off()
	}
	
	jpeg(filename = paste(outputFolder, outputPrefix, datensatz0Name, "_LevelAuswertung_",aktuellerTag, ".jpg"), width = outputWidth, height = outputHeight, units = "px", pointsize = 12, quality = 75, bg = "white", restoreConsole = TRUE)
		
	barplot(tabledData , main=paste("Aktivität am ", aktuellerTag), xlab='Uhrzeit', ylab='Anteil in %', col=heat.colors(4), space=0, names.arg=0:23)
	
	dev.off()
	
}
