# Script created by ActiGraph Auswertung 3

# General settings 
setwd('C:\\Users\\Fritz\\Documents\\Visual Studio 2008\\Projects\\ActiveGraph\\ActigraphAuswertung\\2010-04-01 - Verbesserung\\ActigraphAuswertung\\bin\\Debug\\Temp\\') 
outputWidth = 800
outputHeight = 600
outputPrefix = "t"
outputFolder = "D:\\"

# Import files 
datensatz0 <- read.table('t9leg,F,2CSV.csv', sep=';', header=FALSE) 
datensatz0Datum <- as.vector(datensatz0$V1) 
datensatz0Uhrzeit <- as.vector(datensatz0$V2) 
datensatz0Daten <- as.vector(datensatz0$V3) 
datensatz0Name = "t9leg,F,2CSV.csv"

# Script specific settings
anzahlTage = 14
source('tAuswertung_Tagesschnitt.R') 
