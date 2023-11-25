const sortedArray: number[] = [
    6, 10, 20, 31, 51, 356, 3231, 5666
];

const index = binarySearch(5666, sortedArray);
console.log(index);


function binarySearch(searchNumber: number, numbers: number[]): number {
    let left = 0;
    let right = numbers.length - 1;

    while (left <= right) {
        const mid = Math.floor(left + (right - left / 2))

        if (searchNumber === numbers[mid]) return mid;

        else if (searchNumber > numbers[mid]) left = mid + 1

        else right = mid - 1
    }

    return -1
}
