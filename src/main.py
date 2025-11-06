import random

#field
field = [[]]
width = 10
height = 12

block_freq = 28

# dog
dog = '@'
dogX, dogY = 0,0

# input
dx,dy = 0,0

# финиш
finishX, finishY = 0,0

reached_finish = False

def generate_field():
    for i in range(height):
        field.append([])
        for j in range(width):
            rand_num = random.randint(0, 100)
            if(rand_num<block_freq):
                symbol = '#'
            else:
                symbol = '.'
            field[i].append(symbol)

    global finishX, finishY
    finishX = random.randint(0, width-1)
    finishY = random.randint(0, height-1)
    field[finishY][finishX] = 'Д'

def draw():
    for i in range(height):
        for j in range(width):
            if(i==dogY and j==dogX):
                symbol = dog
            else:
                symbol = field[i][j]
            print(symbol, end='')
        print()

def place_dog():
    global dogX, dogY
    dogX = random.randint(0, width-1)
    dogY = random.randint(0, height-1)

def generate():
    generate_field()
    place_dog()

def get_input():
    dx, dy = 0, 0
    inp = input()
    if(len(inp)==0):
        return (0,0)

    first_symbol = inp.split()[0]

    if(first_symbol=='W' or first_symbol == 'w'):
        dy = -1
    if(first_symbol=='A' or first_symbol == 'a'):
        dx = -1
    if(first_symbol=='S' or first_symbol == 's'):
        dy = 1
    if(first_symbol=='D' or first_symbol == 'd'):
        dx = 1

    return (dx, dy)

def is_end_game():
    return reached_finish

def is_walkable(X,Y):
    if(field[Y][X]=='#'):
        return False
    return True

def can_go_to(newX, newY):
    if(newX<0 or newY<0 or newX >=width or newY >= height):
        return False
    if(not is_walkable(newX, newY)):
        return False
    return True

def go_to(newX, newY):
    global dogX, dogY
    dogX, dogY = newX, newY

def try_go_to(newX, newY):
    if(can_go_to(newX, newY)):
        go_to(newX, newY)

def check_finish():
    global reached_finish
    if(dogX==finishX and dogY==finishY):
        reached_finish = True

def logic():
    try_go_to(dogX+dx, dogY+dy)
    check_finish()

def main():
    generate()
    draw()

    while(not is_end_game()):
        global dx, dy
        dx, dy = get_input()
        logic()
        draw()

    print('УИИИИИИИИИ')

main()