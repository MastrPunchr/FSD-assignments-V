def openFile(file_address): #risky, should be called inside a try block
    if file_address[len(file_address) - 5:len(file_address)] == ".exe":
        print("Can run executable")
    else:
        raise FileNotFoundError("Not an executable")

try:
    openFile("game.png")
except FileNotFoundError as fnf:
    print("File not found", fnf)
except ValueError:
    print("Value Error happened.")
except:
    print("Some error happened.")
finally:
    print("Always runs - Cleanup/logs here")

print("End of program")
