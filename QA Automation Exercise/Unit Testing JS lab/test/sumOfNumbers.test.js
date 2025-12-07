import {sum} from '../01-lab.js'
import {expect} from 'chai'
describe ('Test function sum', () => {
    it ('should return correct sum if array with numbers is passed', () => {
        //Arrange
        let array = [1, 2, 3, 4,];
        let expected = 10;

        //Act
        let result = sum(array);

        //Assert
        expect(result).to.equal(expected);
    }),

    it ('should return same number if the array have one element', () => {

        //Arrange
        let array = [4];
        let expected = 4;

        //Act
        let  result = sum(array);

        //Assert
        expect(result).to.equal(expected);
    }),

    it ('should return zero if the array is empty', () => {

        //Arrange
        let array = [];
        let expected = 0;

        //Act
        let result = sum(array);

        //Assert
         expect(result).to.equal(expected);
    })

    
});