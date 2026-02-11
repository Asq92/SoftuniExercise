import { mathEnforcer } from '../03-exercise.js'
import { describe } from 'mocha'
import { expect } from 'chai'

describe('Test mathEnforcer', () => {
    describe('addFive function', () => {
        it('shoud return undefined if input parameter is not a number', () => {
            expect(mathEnforcer.addFive('42')).to.be.undefined
            expect(mathEnforcer.addFive([42])).to.be.undefined
            expect(mathEnforcer.addFive({})).to.be.undefined
            expect(mathEnforcer.addFive(null)).to.be.undefined
            expect(mathEnforcer.addFive(undefined)).to.be.undefined
        }),
        it('shoud return input parameter plus five', () => {
            expect(mathEnforcer.addFive(10)).to.equal(15)
            expect(mathEnforcer.addFive(100.8)).to.equal(105.8)
            expect(mathEnforcer.addFive(-3)).to.equal(2)
        })
    }),
    describe('subtractTen function', () => {
        it('shoud return undefined if input parameter is not a number', () => {
            expect(mathEnforcer.subtractTen('42')).to.be.undefined
            expect(mathEnforcer.subtractTen([42])).to.be.undefined
            expect(mathEnforcer.subtractTen({})).to.be.undefined
            expect(mathEnforcer.subtractTen(null)).to.be.undefined
            expect(mathEnforcer.subtractTen(undefined)).to.be.undefined
        }),
        it('shoud return input parameter subtract ten', () => {
            expect(mathEnforcer.subtractTen(100)).to.equal(90)
            expect(mathEnforcer.subtractTen(52.45)).to.equal(42.45)
            expect(mathEnforcer.subtractTen(-5)).to.equal(-15)
        })
    }),
    describe('sum function', () => {
        it('shoud return undefined if first input parameter is not a number', () => {
            expect(mathEnforcer.sum('42', 5)).to.be.undefined
            expect(mathEnforcer.sum([42], 5)).to.be.undefined
            expect(mathEnforcer.sum({}), 5).to.be.undefined
            expect(mathEnforcer.sum(null, 5)).to.be.undefined
            expect(mathEnforcer.sum(undefined, 5)).to.be.undefined
        }),
        it('shoud return undefined if second input parameter is not a number', () => {
            expect(mathEnforcer.sum(2, '42')).to.be.undefined
            expect(mathEnforcer.sum(2, [42])).to.be.undefined
            expect(mathEnforcer.sum(2, {})).to.be.undefined
            expect(mathEnforcer.sum(2, null)).to.be.undefined
            expect(mathEnforcer.sum(2, undefined)).to.be.undefined
        }),
        it('shoud return sum if both parameters are number', () => {
            expect(mathEnforcer.sum(5, 7)).to.equal(12)
            expect(mathEnforcer.sum(-5, 7)).to.equal(2)
            expect(mathEnforcer.sum(-5, -17)).to.equal(-22)
            expect(mathEnforcer.sum(5.5, 7.8)).to.equal(13.3)
        })
    })
})
