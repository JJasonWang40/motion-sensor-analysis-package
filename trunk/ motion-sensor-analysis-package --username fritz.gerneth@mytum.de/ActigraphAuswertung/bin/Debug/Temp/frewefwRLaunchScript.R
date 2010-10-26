# Script created by ActiGraph Auswertung 3

# General settings 
setwd('C:\\Users\\Fritz\\Documents\\Visual Studio 2008\\Projects\\ActiveGraph\\ActigraphAuswertung\\2010-04-01 - Verbesserung\\ActigraphAuswertung\\bin\\Debug\\Temp\\') 
outputWidth = 800
outputHeight = 600
outputPrefix = "frewefw"
outputFolder = "D:\\"

# Import files 
datensatz0 <- read.table('frewefw12_ArmCSV.csv', sep=';', header=FALSE) 
datensatz0Datum <- as.vector(datensatz0$V1) 
datensatz0Uhrzeit <- as.vector(datensatz0$V2) 
datensatz0Daten <- as.vector(datensatz0$V3) 
datensatz0Name = "frewefw12_ArmCSV.csv"

# Script specific settings
anzahlTage = 13
source('frewefwAuswertung_Taeglich.R') 
