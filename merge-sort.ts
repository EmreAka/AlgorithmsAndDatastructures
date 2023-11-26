const arr: number[] = [5, 1, 2, 16, 7, 0, -1, 5, 4];

const mergeSort = (array: any[], leftIndex: number, rightIndex: number) => {
    if (leftIndex >= rightIndex) {
        return;
    }

    const middleIndex = Math.floor(leftIndex + (rightIndex - leftIndex) / 2);

    mergeSort(array, leftIndex, middleIndex);
    mergeSort(array, middleIndex + 1, rightIndex);

    merge(array, leftIndex, middleIndex, rightIndex);
};

const merge = (array: any[], left: number, mid: number, right: number) => {
    const leftArrSize = mid - left + 1;
    const rightArrSize = right - mid;

    const leftArr = new Array(leftArrSize);
    const rightArr = new Array(rightArrSize);

    for (let i = 0; i < leftArrSize; i++) {
        leftArr[i] = array[left + i];
    }

    for (let i = 0; i < rightArrSize; i++) {
        rightArr[i] = array[mid + 1 + i];
    }

    let leftIndex = 0;
    let rightIndex = 0;
    let mergedIndex = left;

    while (leftIndex < leftArrSize && rightIndex < rightArrSize) {
        if (leftArr[leftIndex] <= rightArr[rightIndex]) {
            array[mergedIndex] = leftArr[leftIndex];
            leftIndex++;
        } else {
            array[mergedIndex] = rightArr[rightIndex];
            rightIndex++;
        }

        mergedIndex++;
    }

    // Copy remaining elements from leftArr and rightArr if any
    while (leftIndex < leftArrSize) {
        array[mergedIndex] = leftArr[leftIndex];
        leftIndex++;
        mergedIndex++;
    }

    while (rightIndex < rightArrSize) {
        array[mergedIndex] = rightArr[rightIndex];
        rightIndex++;
        mergedIndex++;
    }
};

mergeSort(arr, 0, arr.length - 1);
console.log(arr);
