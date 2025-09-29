def sumIntegers(n):
    total = 0
    for num in range(n+1):
        total += num
    return total

print(sumIntegers(1000000000000))