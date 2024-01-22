import math

def kvadrat(a, b, c):
    x = ((-1*b) + math.sqrt(abs((b*b) - (4*a*c)))) / (2*a)
    return x

def khasakh(q, w, e):
    x = ((-1*w) - math.sqrt(abs((w*w) - (4*q*e)))) / (2*q)
    return x

x, y, z = map(int, input().split())
hariu = kvadrat(x, y, z), khasakh(x, y, z)
print(hariu)

