// When we say tree, we generally mean binary tree.
// Each node has no more than two child nodes.
// Each node has a left node, and a right node.
// In any subtree, left nodes are less than the root node.

// There are balanced and unbalanced trees.
// Balanced => insert: O(log n) -- find: O(log n)
// Unbalanced => insert: O(n) -- find: O(n)

class MyNode {
    right: MyNode
    left: MyNode
    data: number

    constructor(data: number) {
        this.data = data
    }

    insert(value: number) {
        if (value <= this.data) {
            if (this.left === undefined) {
                this.left = new MyNode(value)
            } else {
                this.left.insert(value)
            }
        } else {
            if (this.right === undefined) {
                this.right = new MyNode(value)
            } else {
                this.right.insert(value)
            }
        }
    }

    contains(value: number): boolean {
        if (value === this.data) {
            return true
        } else if (value < this.data) {
            if (this.left === undefined) {
                return false
            } else {
                return this.left.contains(value)
            }
        } else {
            if (this.right === undefined) {
                return false
            } else {
                return this.right.contains(value)
            }
        }
    }

    printInOrder() {
        if (this.left !== undefined) {
            this.left.printInOrder()
        }

        console.log(this.data)

        if (this.right !== undefined) {
            this.right.printInOrder()
        }
    }
}

const myNode = new MyNode(10)
myNode.insert(5)
myNode.insert(15)
myNode.insert(8)

myNode.printInOrder()
