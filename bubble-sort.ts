const numbers = [5, 3, 1, 66, 100, 31, 25, 16, 67, 985, 342, 423, 35]

function bubbleSort(numbers: number[]) {
    for (let j = 0; j < numbers.length; j++) {
        for (let i = 0; i < numbers.length - j; i++) {
            if (numbers[i] > numbers[i + 1]) {
                [numbers[i], numbers[i + 1]] = [numbers[i + 1], numbers[i]]
            }
        }
    }

    return numbers
}

const sortedList = bubbleSort(numbers)

console.log(sortedList)
