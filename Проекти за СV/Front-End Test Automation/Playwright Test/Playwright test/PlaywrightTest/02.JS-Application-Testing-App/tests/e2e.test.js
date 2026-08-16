const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email : "",
    password : "123456",
    confirmPass : "123456",
};

let recipeName = "";

async function loginUser(page, email, password) {
    await page.goto(host);
    await page.click('text=Login');
    await page.locator('input[name="email"]').fill(email);
    await page.locator('input[name="password"]').fill(password);
    await page.click('[type="submit"]');    
    await page.waitForURL(host + '/');
    await page.waitForSelector('nav >> text=Logout');
}

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    
    describe("authentication", () => {
        test('Registration with Valid Data', async () => {
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 10000);
            user.email = `softuni_${random}@softuni.bg`;

            await page.locator('input[name="email"]').fill(user.email);
            await page.locator('input[name="password"]').fill(user.password);
            await page.locator('input[name="conf-pass"]').fill(user.confirmPass);
            await page.click('[type="submit"]'); 
            await page.waitForURL(host + '/');

            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        })

        test('Login with Valid Data', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('input[name="email"]').fill(user.email);
            await page.locator('input[name="password"]').fill(user.password);
            await page.click('[type="submit"]');
            await page.waitForURL(host + '/');
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');


        })

        test('Logout from the Application', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Logout');
            await page.waitForURL(host + '/');
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        })
		
    });

    describe("navbar", () => {
        test('Navigation for Logged-In User', async () => {
            await loginUser(page, user.email, user.password);
            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Discover')).toBeVisible();
            await expect(page.locator('nav >> text=Search')).toBeVisible();
            await expect(page.locator('nav >> text=Create Recipe')).toBeVisible();
            await expect(page.locator('nav >> text=Logout')).toBeVisible();

            await expect(page.locator('nav >> text=Login')).toBeHidden();
            await expect(page.locator('nav >> text=Register')).toBeHidden();

        })

        test('Navigation for Guest User', async () => {
            await page.goto(host);
             await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Discover')).toBeVisible();
            await expect(page.locator('nav >> text=Search')).toBeVisible();
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            await expect(page.locator('nav >> text=Register')).toBeVisible();

            await expect(page.locator('nav >> text=Create Recipe')).toBeHidden();
            await expect(page.locator('nav >> text=Logout')).toBeHidden();


        })

		
    });

    describe("CRUD", () => {
        test('Create a Recipe Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Create Recipe');
            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 10000);
                recipeName = `Recipe_${random}`;

                await page.locator('#recipeName').fill(recipeName);
                await page.locator('#recipeImage').fill('/image/pancakes.jpg');
                await page.locator('#preparationTime').fill('20');
                await page.locator('#sharedBy').fill('SoftUni Tester');
                await page.locator('#cuisineType').fill('International');
                await page.locator('[name="steps"]').fill('This is a test recipe.');
                await page.click('[type="submit"]');
                await page.waitForURL(host + '/discover');
                await expect(page.locator(`text=${recipeName}`)).toBeVisible();
                expect(page.url()).toBe(host + '/discover');
        })

        test('Edit a Recipe Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Search');
            await page.waitForSelector('form');
            await page.locator('input[name="search"]').fill(recipeName);
            await page.click('[type="submit"]');
            await page.waitForSelector(`text=${recipeName}`);
            await page.click(`text=${recipeName}`);
            await page.waitForSelector('text=Edit');
            await page.click('text=Edit');
            await page.waitForSelector('form');

            recipeName = recipeName + '_Edited';
            await page.locator('#recipeName').fill(recipeName);
            await page.click('[type="submit"]');
            await expect(page.locator(`text=${recipeName}`)).toBeVisible();
            
        })

        test('Delete a Recipe Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Search');
            await page.waitForSelector('form');
            await page.locator('input[name="search"]').fill(recipeName);
            await page.click('[type="submit"]');
            await page.waitForSelector(`text=${recipeName}`);
            await page.click(`text=${recipeName}`);
            await page.click('text=Delete');

            await expect(page.locator(`text=${recipeName}`)).not.toBeVisible();
            expect(page.url()).toBe(host + '/discover');

        })
		
    });
});