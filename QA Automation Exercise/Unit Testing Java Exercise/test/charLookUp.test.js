import {lookupChar} from '../02-exercise.js'
import { describe } from 'mocha'
import { expect } from 'chai'

describe('test_charLokUp', () => {
    it('shoud return undefined if first parameter is not a string', () => {
    expect(lookupChar(42, 5)).to.be.undefined
    expect(lookupChar([], 5)).to.be.undefined
    expect(lookupChar({}, 5)).to.be.undefined
    expect(lookupChar(null, 5)).to.be.undefined
    expect(lookupChar(undefined, 5)).to.be.undefined
    })

    it('shoud return undefined if second parameter is not an integer number', () => {
        expect(lookupChar('valid text', '2')).to.be.undefined
        expect(lookupChar('valid text', 5.5)).to.be.undefined
        expect(lookupChar('valid text', [4])).to.be.undefined
        expect(lookupChar('valid text', {})).to.be.undefined
        expect(lookupChar('valid text', null)).to.be.undefined
        expect(lookupChar('valid text', undefined)).to.be.undefined
    })
    it('shoud return "Incorrect index" if index is not valid', () => {
        //Arrange
        let expected = "Incorrect index"

        //Act & Assert
        expect(lookupChar('hello', -1)).to.equal(expected)
        expect(lookupChar('hello', 5)).to.equal(expected)
        expect(lookupChar('hello', 10)).to.equal(expected)
    })
    it('Happy Path', () => {
        expect(lookupChar('Anastasiq', 0)).to.equal('A')
        expect(lookupChar('Anastasiq', 1)).to.equal('n')
        expect(lookupChar('Anastasiq', 4)).to.equal('t')
    })
})