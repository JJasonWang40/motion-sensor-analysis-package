worn = vector(mode = "logical", length = 0)

for(i in 1:length(datensatz0Daten)) {
	last20Begin = i - 20
	next20End = i + 20

	currentDatasetGreaterThan5 = (datensatz0Daten[i] > 5)

	if (last20Begin < 1) {
		last20Begin = 1
	}
	if (next20End >= length(datensatz0Daten)) {
		next20End = length(datensatz0Daten) - 1
	}
	datasetsBeforeCurrentWithVmuGreater5 = 0
	for (j in last20Begin:i) {
		if (datensatz0Daten[j] > 5) {
			datasetsBeforeCurrentWithVmuGreater5 = datasetsBeforeCurrentWithVmuGreater5 + 1
		}
	}
	datasetsAfterCurrentWithVmuGreater5 = 0
	for (j in i:next20End) {
		if (datensatz0Daten[j] > 5) {
			datasetsAfterCurrentWithVmuGreater5 = datasetsAfterCurrentWithVmuGreater5 + 1
		}
	}

	currentDatasetWorn = 0

	if (currentDatasetGreaterThan5 && (datasetsBeforeCurrentWithVmuGreater5 > 1 || datasetsAfterCurrentWithVmuGreater5 > 1)) {
		currentDatasetWorn = 1
	}

	if (!currentDatasetGreaterThan5 && (datasetsBeforeCurrentWithVmuGreater5 > 1 && datasetsAfterCurrentWithVmuGreater5 > 1)) {
		currentDatasetWorn = 1
	}
	
	if (currentDataSetWorn == 1) {
		worn = c(worn, datensatz0Daten[i])
	}
}


datensatz0Daten = worn
