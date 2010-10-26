
df <- StructTS(DatenSpalte)
# Fuehrt eine Kalman-basierte Glättung der Werte von df durch
DatenSpalte <- tsSmooth(df)