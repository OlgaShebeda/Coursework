$(document).ready(function () {

    function leftshoe() {
        $('.leftshoe')
		.velocity({
		    rotateZ: "2deg",
		    translateX: "-2px",
		    translateY: "-2px"
		},
		{ duration: 2000 })
		.velocity({
		    rotateZ: "0deg",
		    translateX: "0px",
		    translateY: "0px"
		},
		{
		    duration: 500,
		    easing: "liner"
		});
    }

    function rightshoe() {
        $('.rightshoe')
		.velocity({
		    rotateZ: "1deg",
		    translateX: "1px",
		    translateY: "1px"
		},
		{
		    duration: 200,
		    easing: "liner"
		})
		.velocity({
		    rotateZ: "0deg",
		    translateX: "0px",
		    translateY: "0px"
		},
		{
		    duration: 500,
		    easing: "liner"
		});
    }

    function notebook() {
        $('.notebook')
		.velocity({
		    rotateZ: "0.5deg"
		},
		{
		    duration: 200,
		    easing: "liner"
		})
		.velocity({ rotateZ: "-0.5deg" },
		{
		    duration: 200,
		    easing: "liner"
		});
    }

    function lefthand() {
        $('.lefthand')
		.velocity({
		    rotateZ: "5deg",
		    translateX: "5x",
		    translateY: "5px"
		},
		{
		    duration: 200,
		    easing: "liner",
		    loop: true
		});
    }

    function righthand() {
        $('.righthand')
		.velocity({
		    rotateZ: "5deg",
		    translateX: "-5x",
		    translateY: "-5px"
		},
		{
		    duration: 200,
		    easing: "liner",
		    loop: true
		});
    }

    function head() {
        $('.head')
		.velocity({
		    rotateZ: "3deg"
		},
		{
		    duration: 400,
		    delay: 2000
		})

		.velocity({
		    rotateZ: "0deg"
		},
		{
		    duration: 400,
		    delay: 6000
		})
		.velocity({
		    rotateZ: "-3deg"
		},
		{
		    duration: 400,
		    delay: 4000
		});
    }

    function head_next() {
        $('.head')
		.velocity({
		    rotateZ: "3deg"
		},
		{ duration: 400 })

		.velocity({
		    rotateZ: "0deg"
		},
		{
		    duration: 400,
		    delay: 6000
		})
		.velocity({
		    rotateZ: "-3deg"
		},
		{
		    duration: 400,
		    delay: 4000
		});
    }

    function body_animation() {
        $('.body-animation')
		.velocity({
		    rotateZ: "4deg",
		    translateX: "-32px",
		    translateY: "-12px"
		},
		{
		    duration: 1000,
		    delay: 6000
		})
		.velocity({
		    rotateZ: "-6deg",
		    translateX: "52px",
		    translateY: "30px"
		},
		{
		    duration: 1000,
		    delay: 10000
		})
		.velocity({
		    rotateZ: "0deg",
		    translateX: "0px",
		    translateY: "0px"
		}, {
		    duration: 1000,
		    delay: 13000
		});
    }

    function body_animation_next() {
        $('.body-animation')
		.velocity({
		    rotateZ: "4deg",
		    translateX: "-32px",
		    translateY: "-12px"
		},
		{
		    duration: 1000,
		    delay: 6000
		})
		.velocity({
		    rotateZ: "-6deg",
		    translateX: "52px",
		    translateY: "30px"
		},
		{
		    duration: 1000,
		    delay: 10000
		})
		.velocity({
		    rotateZ: "0deg",
		    translateX: "0px",
		    translateY: "0px"
		}, {
		    duration: 1000,
		    delay: 13000
		});
    }

    function eyes() {
        $('.left-eye, .right-eye')
		.velocity({
		    translateX: "-5px"
		}, { duration: 8000 })
		.velocity({
		    translateX: "0px"
		}, { duration: 400 });
    }

    function eyes2() {
        $('.left-eye, .right-eye').css('background-position', '-165px -365px');
        setTimeout(function () {
            $('.left-eye, .right-eye').css('background-position', '-165px -350px');
        }, 300);
    }

    setInterval(leftshoe, 5000);
    setInterval(rightshoe, 700);
    setInterval(notebook, 400);
    setInterval(head_next, 16000);
    setInterval(body_animation_next, 33000);
    setInterval(eyes, 8500);
    setInterval(eyes2, 8000);

    lefthand();
    righthand();
    head();
    body_animation();
    eyes();

});