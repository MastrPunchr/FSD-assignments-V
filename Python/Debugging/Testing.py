def customPrint(message):
    print("Custom Printing: ", end="")
    print(message)

customPrint("start")
for i in range(10):
    customPrint(i)
customPrint("end")