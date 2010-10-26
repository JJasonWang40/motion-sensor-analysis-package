# Script created by ActiGraph Auswertung 3

# General settings 
setwd('C:\\Users\\Fritz\\Documents\\Visual Studio 2008\\Projects\\ActiveGraph\\ActigraphAuswertung\\2010-04-01 - Verbesserung\\ActigraphAuswertung\\bin\\Debug\\Temp\\') 
outputWidth = 800
outputHeight = 600
outputPrefix = "test23"
outputFolder = "D:\\"

# Import files 
datensatz0 <- read.table('test2312_ArmCSV.csv', sep=';', header=FALSE) 
datansatz0Datum <- as.vector(datensatz0$V1) 
datensatz0Uhrzeit <- as.vector(datensatz0$V2) 
datensatz0Daten <- as.vector(datensatz0$V3) 
datensatz0Name = "test2312_ArmCSV.csv"

# Script specific settings
anzahlTage = 13
source('test23Auswertung_Tagesschnitt.R') 
