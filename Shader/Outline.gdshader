shader_type canvas_item;

uniform float _Width:hint_range(0.0f, 10.0f);
uniform vec4 _OutlineColor:source_color;
uniform float _TimeSpeed:hint_range(0.0f, 10.0f);

void fragment()
{
	float widthDelta = 1.0f*_Width/float(textureSize(TEXTURE,0).x);
	float heightDelta = 1.0f*_Width/float(textureSize(TEXTURE,0).y);
	vec4 color = texture(TEXTURE,UV);
	
	float alpha = 8.0f * color.a;
	float time = abs(sin(TIME*_TimeSpeed));
	
	alpha -= texture(TEXTURE,UV+vec2(widthDelta,0.0f)).a;
	alpha -= texture(TEXTURE,UV+vec2(-widthDelta,0.0f)).a;
	alpha -= texture(TEXTURE,UV+vec2(0.0f,heightDelta)).a;
	alpha -= texture(TEXTURE,UV+vec2(0.0f,-heightDelta)).a;
	alpha -= texture(TEXTURE,UV+vec2(widthDelta,heightDelta)).a;
	alpha -= texture(TEXTURE,UV+vec2(-widthDelta,-heightDelta)).a;
	alpha -= texture(TEXTURE,UV+vec2(widthDelta,heightDelta)).a;
	alpha -= texture(TEXTURE,UV+vec2(-widthDelta,-heightDelta)).a;
	
	vec4 finalColor = mix(color,mix(color,_OutlineColor,time),clamp(alpha,0.0f,1.0f));
	
	COLOR = vec4(finalColor.rgb,clamp(alpha+color.a,0.0f,1.0f));
}