const puppeteer = require('puppeteer');
const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const parser = bodyParser.json();

//open page and recieve result
async function openPage(browser, min, max){	
	var page = await browser.newPage();
	await page.goto('https://www.calculatorsoup.com/calculators/statistics/random-number-generator.php');
		
	await page.$eval("#min", (el, val) => el.value = val, min);
	await page.$eval("#max", (el, val) => el.value = val, max);
	await page.$eval("#num_samples", el => el.value = "1");
	await page.click("#calculateButton");
	var elem = await page.waitForSelector(".alignCenter.numbers", {timeout: 2000});
	var val = await elem.evaluate(el => el.textContent);
	return parseInt(val);
}

//open site and recieve result
async function openSite(page, min, max){
	await page.goto('https://www.calculatorsoup.com/calculators/statistics/random-number-generator.php');
		
	await page.$eval("#min", (el, val) => el.value = val, min);
	await page.$eval("#max", (el, val) => el.value = val, max);
	await page.$eval("#num_samples", el => el.value = "1");
	await page.click("#calculateButton");
	var elem = await page.waitForSelector(".alignCenter.numbers", {timeout: 2000});
	var val = await elem.evaluate(el => el.textContent);
	page.close();
	return parseInt(val);
}

//declare event for start multiple browsers
async function browserStarter(min, max, count){	
	const browser = await puppeteer.launch();	
		
	var tasks = [];
		
	for (var i = 0; i < count; i++) {
		tasks.push(openPage(browser, min, max));		
	}
	
	var result = await Promise.all(tasks);
	await browser.close();	
	return result;
}

//I didn't understand, is it important to first open pages and then generate or browserStarter() valid too?
async function manyPagesStarter(min, max, count){	
	const browser = await puppeteer.launch();	
		
	var tasks = [];
	var pages = [];
	
	for (var i = 0; i < count; i++) {
		pages.push(await browser.newPage());		
	}
		
	for (var i = 0; i < count; i++) {
		tasks.push(openSite(pages[i], min, max));		
	}
	
	var result = await Promise.all(tasks);
	await browser.close();	
	return result;
}


//start http server to recieve
//{"min_number": 5, "max_number": 10, "count": 3}

//first create browser instance, then call pages and get results
app.post('/generate', parser, async function (request, response) {
	var min = request.body.min_number;
	var max = request.body.max_number;
	var count = request.body.count;
	
	var result = await browserStarter(min, max, count);
		
	response.send({result: result});
})

//first create browser and pages, then open sites and get results
app.post('/generate2', parser, async function (request, response) {
	var min = request.body.min_number;
	var max = request.body.max_number;
	var count = request.body.count;
	
	var result = await manyPagesStarter(min, max, count);
	
	response.send({result: result});
})

var server = app.listen(8081, function() {
   var host = server.address().address
   var port = server.address().port
   
   console.log("Example app listening at http://%s:%s", host, port)
})