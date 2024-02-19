l=[]
hariu = []
min1 = 999999999999
if __name__ == '__main__':
    a= int(input())
    for i in range(a):
        name = input()
        score = float(input())
        l.append([name, score])
    l.sort()
    hariu.sorted(list(set(hariu)))
    hariu.remove(min(hariu))
    for x in range(len(l)):
        if l[x][1] ==  min(hariu):
            print(l[x][0])